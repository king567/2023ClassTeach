[] 使用者登陸
	帳號：test
	密碼：123

[] FormMediaInfo 
	在查詢時傳入一物件，當作查詢條件，查詢完畢會載入影片資料

[] FormNews
	新增一筆影片資訊，同時新增影片的類型、OTT平台，關聯資料

[] FormUpdate
	從FormMediaInfo DataGridView 點擊獲得欲編輯的影片 Id ，將 Id 傳入進 FormUpdate，
	進行編輯，可以編輯影片標題、類型(Genre(恐怖片、動作片))、OTT平台(Netflix、Youtube)、
	類別(電影、電視劇)、影片上映日期、簡介。

	Save按鈕：儲存修改資訊
	Delete按鈕：根據影片 Id 刪除影片，同時刪除相關的關聯

[] FromLogin
	使用者登陸，會驗證帳號欄位，如登陸時密碼或帳號輸入錯誤時會提示錯誤

[] FormCreateAccount
	創建使用者帳號，會驗證帳號名稱是否被取過
