using BookStore.Site.Models.EFmodels;
using BookStore.Site.Models.Infra;
using BookStore.Site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.Site.Controllers
{
    public class MembersController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterVm vm)
        {
            if(!ModelState.IsValid)
            {
				return View(vm);
			}
            try
            {
                RegisterMember(vm);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vm);
            }
            return View("RegisterComfirm");
        }
        public ActionResult ActiveRegister(int memberId,string confirmCode)
        {
            if(memberId <= 0 || string.IsNullOrEmpty(confirmCode))
            {
                return View();
            }

            var db = new AppDbContext();

			// 根據 memberId , confirmCode Member
            var member = db.Members.FirstOrDefault(m => m.Id == memberId && m.ConfirmCode == confirmCode && m.IsConfirmed == false);
            if(member == null)
            {
				return View();
			}

            // 將他更新為已確認
            member.IsConfirmed = true;
            member.ConfirmCode = null;
            db.SaveChanges();

            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
			FormsAuthentication.SignOut();
			return RedirectToAction("Login");
		}

        [Authorize]
        public ActionResult EditProfile()
        {
            var currentUserAccount = User.Identity.Name;
            var vm = GetMemberProfile(currentUserAccount);
            return View(vm);
        }

		[Authorize]
        [HttpPost]
		public ActionResult EditProfile(EditProfileVm vm)
        {
            var currentUserAccount = User.Identity.Name;
            if(!ModelState.IsValid)
            {
				return View(vm);
			}
            try
            {
                UpdateProfile(vm, currentUserAccount);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
				return View(vm);
            }
            return View();
        }

		[Authorize]
		public ActionResult EditPassword()
        {
			return View();
		}

		[Authorize]
		[HttpPost]
        public ActionResult EditPassword(EditPasswordVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            try
            {
                var currentUserAccount = User.Identity.Name;
                ChangePassword(vm, currentUserAccount);
            }
            catch (Exception ex)
            {
				ModelState.AddModelError("", ex.Message);
				return View(vm);
			}

            return RedirectToAction("Index");
		}

        public ActionResult ForgotPassword()
        {
			return View();
		}

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordVm vm)
        {
			if (!ModelState.IsValid)
            {
				return View(vm);
			}
			var urlTemplate = Request.Url.Scheme + "://" + // 生成 http:.// 或 https://
                            Request.Url.Authority + "/" + // 生成網域名稱或 ip
                            "Members/ResetPassword?memberid={0}&confirmCode={1}"; // 生成網頁 url

            try
            {
                ProccessRestPassword(vm.Account,vm.Email, urlTemplate);
            }
            catch(Exception ex)
            {
				ModelState.AddModelError("", ex.Message);
				return View(vm);
			}

			return View("ForgotPasswordComfirm");
		}

		private void ProccessRestPassword(string account, string email, string urlTemplate)
		{
			var db = new AppDbContext();

            // 檢查 account,email 正確性

            var memberInDb = db.Members.FirstOrDefault(m => m.Account == account);
            if(memberInDb == null)
            {
				throw new Exception("帳號不存在");
			}
            if(string.Compare(email,memberInDb.Email,StringComparison.CurrentCultureIgnoreCase) != 0)
            {
                throw new Exception("帳號 或 Email不正確");
            }
            if(memberInDb.IsConfirmed == false)
            {
				throw new Exception("您尚未開通會員資格，請先收確認信，並點選信裡的連結，完成認證，才能登入本網站");
			}

            var confirmCode = Guid.NewGuid().ToString("N");
            memberInDb.ConfirmCode = confirmCode;
            db.SaveChanges();

            // 寄出重設密碼的信件

            var url = string.Format(urlTemplate,memberInDb.Id,confirmCode);

            new EmailHelper().SedForgetPasswordEmail(url,memberInDb.Name,memberInDb.Email);
		}

		private void ChangePassword(EditPasswordVm vm, string account)
		{
            var db = new AppDbContext();

			var memberInDb = db.Members.FirstOrDefault(m => m.Account == account);
            if(memberInDb == null)
            {
                throw new Exception("帳號不存在");
            }
            var salt = HashUtility.GetSalt();

            //判斷輸入的原始密碼是否正確
            var hashOrigPassword = HashUtility.ToSHA256(vm.OriginalPassword, salt);

            if(string.Compare(memberInDb.EncryptedPassword,hashOrigPassword,true) != 0)
            {
				throw new Exception("原始密碼不正確");
			}

            // 將新密碼雜湊
            var hashNewPassword = HashUtility.ToSHA256(vm.Password, salt);

            // 更新紀錄
            memberInDb.EncryptedPassword = hashNewPassword;
            db.SaveChanges();
		}

		private void UpdateProfile(EditProfileVm vm, string account)
		{
            // 利用 vm.Id 去資料庫取得 Member
            var db = new AppDbContext();
            var memberInDb = db.Members.FirstOrDefault(m => m.Account == account);

			if (memberInDb.Account != account)
            {
				throw new Exception("您沒有權限修改別人的資料");
			}

            memberInDb.Name = vm.Name;
            memberInDb.Email = vm.Email;
            memberInDb.Mobile = vm.Mobile;

            db.SaveChanges();
		}

		private EditProfileVm GetMemberProfile(string account)
		{
			var db = new AppDbContext();
			var member = db.Members.FirstOrDefault(m => m.Account == account);

			if (member == null)
			{
				throw new Exception("帳號不存在");
			}

			var vm = member.ToEditProfileVm();

			return vm;
		}
		public ActionResult Login()
        {
			return View();
		}

        [HttpPost]
		public ActionResult Login(LoginVM vm)
        {
            if(!ModelState.IsValid)
            {
                return View(vm);
            }

            try
            {
                ValidLogin(vm);
            }
            catch(Exception ex)
            {
				ModelState.AddModelError("", ex.Message);
                return View(vm);
			}

            var proccessResult = ProccessLogin(vm);

            Response.Cookies.Add(proccessResult.Cookie);

            return Redirect(proccessResult.ReturnUrl);
        }

        private void ValidLogin(LoginVM vm)
        {
            var db = new AppDbContext();

            var member = db.Members.FirstOrDefault(m => m.Account == vm.Account);
            if(member == null)
            {
				throw new Exception("帳號或密碼錯誤");//原則上不要告知細節
			}
            if(member.IsConfirmed == false)
            {
                throw new Exception("您尚未開通會員資格，請先收確認信，並點選信裡的連結，完成認證，才能登入本網站");
            }

            // 將vm裡的密碼先雜湊後 再與db裡的密碼比對
            var salt = HashUtility.GetSalt();

            var hashPassword = HashUtility.ToSHA256(vm.Password,salt);

            if(string.Compare(member.EncryptedPassword,hashPassword,true) != 0)
            {
                throw new Exception("帳號或密碼有誤");
            }
        }

		private (string ReturnUrl, HttpCookie Cookie) ProccessLogin(LoginVM vm)
		{
            var rememberMe = false; // 如果 LoginVm 裡有一個 RememberMe 的屬性，記得要設定
            var account = vm.Account;
            var roles = string.Empty; // 再本範例 沒有用到角色的權限 所以存入空白

            // 建立一張認證票
            var ticket = new FormsAuthenticationTicket(
                1, // 版本別 沒特別用處
                account, 
                DateTime.Now, // 發行日
                DateTime.Now.AddDays(2), // 到期日
                rememberMe, // 是否續存
                roles, //userdata
                "/" // cookie 位置
            );

            // 將它加密
            var value = FormsAuthentication.Encrypt(ticket);
            // 存入cookie
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, value);
            // 取得 return url
            var url = FormsAuthentication.GetRedirectUrl(account, true); // 第二個引數沒有用處

            return (url, cookie);
		}

		// 這支 method 如何實作註冊功能?
		// 直接叫用 EF
		// 叫用 MemberService
		private void RegisterMember(RegisterVm vm)
		{
			var db = new AppDbContext();

			// 判斷帳號是否已經存在
			var memberInDb = db.Members.FirstOrDefault(m => m.Account == vm.Account);
			if (memberInDb != null)
			{
				throw new Exception("帳號已經存在");
			}

			// 將 vm 轉換成 Member
			var member = vm.ToEFModel();

			// 叫用 EF 寫入資料庫
			db.Members.Add(member);
			db.SaveChanges();
		}

	}
}