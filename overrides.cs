if(isObject(OPT_ChatSize0)) { OPT_ChatSize0.setVisible(0); }
if(isObject(OPT_ChatSize1)) { OPT_ChatSize1.setVisible(0); }
if(isObject(OPT_ChatSize2)) { OPT_ChatSize2.setVisible(0); }
if(isObject(OPT_ChatSize3)) { OPT_ChatSize3.setVisible(0); }
if(isObject(OPT_ChatSize4)) { OPT_ChatSize4.setVisible(0); }
if(isObject(OPT_ChatSize5)) { OPT_ChatSize5.setVisible(0); }
if(isObject(OPT_ChatSize6)) { OPT_ChatSize6.setVisible(0); }
if(isObject(OPT_ChatSize7)) { OPT_ChatSize7.setVisible(0); }
if(isObject(OPT_ChatSize8)) { OPT_ChatSize8.setVisible(0); }
if(isObject(OPT_ChatSize9)) { OPT_ChatSize9.setVisible(0); }
if(isObject(OPT_ChatSize10)) { OPT_ChatSize10.setVisible(0); }
if(isObject(ExampleChat)) { ExampleChat.setVisible(0); }

function addChatSettingsButton() {

	%a = new GuiSwatchCtrl(HideChatSizeText) {
		profile = "GuiDefaultProfile";
		horizSizing = "right";
		vertSizing = "bottom";
		position = "313 149";
		extent = "59 17";
		minExtent = "59 17";
		enabled = "1";
		visible = "1";
		clipToParent = "1";
		color = "243 243 243 255";
	};
	OptGraphicsPane.add(%a);
	
	%button = new GuiBitmapButtonCtrl(ChatSettingsButton) {
		profile = "BlockButtonProfile";
		horizSizing = "right";
		vertSizing = "bottom";
		position = "389 122";
		extent = "140 30";
		minExtent = "8 2";
		enabled = "1";
		visible = "1";
		clipToParent = "1";
		command = "openCustomChatSettings();";
		text = "Chat Settings";
		groupNum = "-1";
		buttonType = "PushButton";
		bitmap = "base/client/ui/button1";
		lockAspectRatio = "0";
		alignLeft = "0";
		alignTop = "0";
		overflowImage = "0";
		mKeepCached = "0";
		mColor = "255 255 255 255";
	};
	OptGraphicsPane.add(%button);
	
}
if(!isObject(ChatSettingsButton)) { addChatSettingsButton(); }