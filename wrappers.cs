function updateFontFamily(%font) {
	BlockChatTextSize1Profile.fontType = %font;
	HudChatTextEditSize1Profile.fontType = %font;
	BlockChatTextSize1Profile.updateFont();
	HudChatTextEditSize1Profile.updateFont();
}
function updateFontSize(%size) {
	BlockChatTextSize1Profile.fontSize = %size;
	HudChatTextEditSize1Profile.fontSize = %size;
	BlockChatTextSize1Profile.updateFont();
	HudChatTextEditSize1Profile.updateFont();
}

function updateLinkColor(%color) {
	BlockChatTextSize1Profile.fontColorLink = %color;
}
function updateVisitedLinkColor(%color) {
	BlockChatTextSize1Profile.fontColorLinkHL = %color;
}

function setChatTextOutline(%bool) {
	BlockChatTextSize1Profile.doFontOutline = mClamp(%bool, 0, 1);
}
function setChatTextOutlineColor(%color) {
	BlockChatTextSize1Profile.fontOutlineColor = %color;
}

function setChatColors() {
	for(%i=0;%i<10;%i++) {
		BlockChatTextSize1Profile.fontColors[%i] = $Pref::Client::CustomChat::Color[%i];
	}
}
setChatColors();

function updateChatBoxColor(%color) {
	CustomChatBackground.color = %color;
}

function resizeChatBox(%x, %y, %width) {
	%ext = CustomChatBackground.getExtent();
	CustomChatBackground.resize(%x, %y, %width, getWord(%ext, 1));
}

//v0.4.0
function updateFontFamily_WT(%font) {
	CC_whosTalkingText.fontType = %font;
	CC_whosTalkingText.updateFont();
}
function updateFontSize_WT(%size) {
	CC_whosTalkingText.fontSize = %size;
	CC_whosTalkingText.updateFont();
}
function setChatTextOutline_WT(%bool) {
	CC_whosTalkingText.doFontOutline = mClamp(%bool, 0, 1);
}
function setChatTextOutlineColor_WT(%color) {
	CC_whosTalkingText.fontOutlineColor = %color;
}
function updateTextColor_WT(%color) {
	CC_whosTalkingText.fontColor = %color;
	CC_whosTalkingText.updateFont();
}