[V] add EFmodel
====
會員系統
[V] add 註冊會員系統
	add Models/Infra/HashUtility.cs
	add AppSetting,<add key="salt" value="arfuighuig$fasfh">
	add Models/ViewModels/RegisterVm.cs


[V] 實作 新會員 Email 確認功能

	會員啟用的 url: /Members/ActiveRegister?memberId=99&comfirmCode=ttttttt
	modift MembersController
		add ActiveRegister(member,confirmCode)
	add Views/Members/ActiveRegister.cshtml


[V] 實作 登入/登出功能 2023/09/14  01:56 PM
	只有帳密正確而且正式開通的會員才允許登入，實作之前，請先個別建立一個已/未開通的會員紀錄 方便測試


[Working on] 實作 修改個人基本資料-建立會員中心頁
	add Models/ViewModels/EditProfileVm.cs
	add Models/ViewModels/MemberExts.cs
[] 發comfirm email 給新註冊會員