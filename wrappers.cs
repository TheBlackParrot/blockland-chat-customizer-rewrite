function updateFontFamily(%font) {
	BlockChatTextSize1Profile.fontType = %font;
}
function updateFontSize(%size) {
	BlockChatTextSize1Profile.fontSize = %size;
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