using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace BookStore.Site.Models.Infra
{
	public class EmailHelper
	{
		private string senderEmail = "king0922go@gmail.com";

		public void SedForgetPasswordEmail(string url,string name,string email)
		{
			var subject = "[重設計密碼通知]";
			var body = $"Hi {name} 您好，<br/> 請點擊此連結[a href='{url}' target='_blank'我要重設密碼</a>],以進行重設密碼,如果您沒有提出申請,請忽略本信,謝謝";

			var from = senderEmail;
			var to = email;
			SendViaGoogle(from,to,subject,body);

		}

		public void SendConfirmRegisterEmail(string url,string name,string email)
		{

		}

		public virtual void SendViaGoogle(string from,string to,string subject,string body)
		{
			var path = HttpContext.Current.Server.MapPath("~/files/");
			CreateTextFile(path,from,to,subject,body);
			return;
		}

		private void CreateTextFile(string path,string from,string to,string subject,string body)
		{
			var fileName = $"{to.Replace("@","_")}{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.txt";

			//文字檔案的完整路徑
			var filePath = Path.Combine(path,fileName);

			//檔案內容
			var contents = $@"form:{from}
to:{to}
subject:{subject}

{body}";
			//建立文字檔,採用UTF8編碼
			File.WriteAllText(filePath,contents,Encoding.UTF8);
		}
	}
}