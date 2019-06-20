if(!$CustomChat::InitGUI) {
	exec("./gui/CC_whosTalkingText.gui");
	chatWhosTalkingText.setProfile(CC_whosTalkingText);
	exec("./gui/CustomChatSettings.gui");
	exec("./gui/swatches/main.cs");
	exec("./gui/CustomChatColorGui.gui");
	$CustomChat::InitGUI = 1;
}

function revertCustomChatSettings() {
	for(%i=0;%i<10;%i++) {
		%obj = "CC_EscapeColorBox" @ %i;
		%obj.mColor = $Pref::Client::CustomChat::Color[%i];
	}

	// i'll figure out some way to make this more dynamic at a later time
	for(%i=0;%i<10;%i++) {
		%obj = "CC_RandomNameColorBox" @ %i;
		%obj.mColor = HexToRGB($Pref::Client::CustomChat::RandomNameColor[%i]) SPC "255";
	}

	%window = CustomChatWindow;

	CC_FontFamilyInput.setValue($Pref::Client::CustomChat::FontFamily);
	CC_FontSizeInput.setValue(mClamp($Pref::Client::CustomChat::FontSize, 4, 64));

	CC_LinkColorBox.mColor = $Pref::Client::CustomChat::LinkColor;
	CC_LinkVisitedColorBox.mColor = $Pref::Client::CustomChat::LinkVisitedColor;

	CC_TextOutlinesCheck.setValue(mClamp($Pref::Client::CustomChat::EnableOutline, 0, 1));
	CC_OutlineColorBox.mColor = $Pref::Client::CustomChat::OutlineColor;

	CC_TextShadowsCheck.setValue(mClamp($Pref::Client::CustomChat::EnableShadow, 0, 1));
	CC_ShadowColorBox.mColor = HexToRGB($Pref::Client::CustomChat::ShadowColor) SPC "255";
	CC_ShadowXInput.setValue(mFloor($Pref::Client::CustomChat::ShadowX));
	CC_ShadowYInput.setValue(mFloor($Pref::Client::CustomChat::ShadowY));

	CC_StripFontTagCheck.setValue(mClamp($Pref::Client::CustomChat::RemoveFontTags, 0, 1));
	CC_StripColorTagCheck.setValue(mClamp($Pref::Client::CustomChat::RemoveColorTags, 0, 1));
	CC_StripBitmapTagCheck.setValue(mClamp($Pref::Client::CustomChat::RemoveBitmapTags, 0, 1));

	CC_MaxBitmapHeightInput.setValue(mClamp($Pref::Client::CustomChat::MaxBitmapHeight, 4, 64));

	CC_ChatBackgroundCheck.setValue(mClamp($Pref::Client::CustomChat::EnableChatBackground, 0, 1));
	CC_ChatBackgroundWidthInput.setValue(mFloor($Pref::Client::CustomChat::BackgroundWidth));
	CC_ChatBackgroundXInput.setValue(mFloor($Pref::Client::CustomChat::BackgroundX));
	CC_ChatBackgroundYInput.setValue(mFloor($Pref::Client::CustomChat::BackgroundY));
	CC_ChatBackgroundColorBox.mColor = $Pref::Client::CustomChat::BackgroundColor;

	CC_NameColorBox.mColor = HexToRGB($Pref::Client::CustomChat::NameColor) SPC "255";
	CC_SelfNameColorBox.mColor = HexToRGB($Pref::Client::CustomChat::SelfNameColor) SPC "255";
	CC_RandomizeNameColorsCheck.setValue(mClamp($Pref::Client::CustomChat::EnableRandomNameColors, 0, 1));
	CC_SlayerOverrideColorsCheck.setValue(mClamp($Pref::Client::CustomChat::EnableSlayerNameColors, 0, 1));

	CC_ClanTagsCheck.setValue(mClamp($Pref::Client::CustomChat::EnableClanTags, 0, 1));
	CC_ClanTagColorBox.mColor = HexToRGB($Pref::Client::CustomChat::ClanTagsColor) SPC "255";

	CC_MessageColorBox.mColor = HexToRGB($Pref::Client::CustomChat::MessageColor) SPC "255";
	CC_SelfMessageColorBox.mColor = HexToRGB($Pref::Client::CustomChat::SelfMsgColor) SPC "255";

	for(%i=0;%i<3;%i++) {
		%obj = "CC_LoggingMode" @ %i;
		%obj.setValue($Pref::Client::CustomChat::LogMode == %i ? 1 : 0);
	}
	%window.loggingMode = $Pref::Client::CustomChat::LogMode;
	CC_LogDirInput.setValue($Pref::Client::CustomChat::LogDir);
	CC_StripMLCheck.setValue(mClamp($Pref::Client::CustomChat::StripMLControlChars, 0, 1));
	CC_EchoChatCheck.setValue(mClamp($Pref::Client::CustomChat::EchoChatToConsole, 0, 1));

	for(%i=0;%i<3;%i++) {
		%obj = "CC_MsgSoundSetting" @ %i;
		%obj.setValue($Pref::Client::CustomChat::SoundNotificationMode == %i ? 1 : 0);
	}
	%window.msgSoundSetting = $Pref::Client::CustomChat::SoundNotificationMode;
	CC_NewMsgSoundInput.setValue($Pref::Client::CustomChat::MessageSoundFilename);
	CC_SentMsgSoundInput.setValue($Pref::Client::CustomChat::SelfMessageSoundFilename);
	CC_EnableBuzzwordsCheck.setValue(mClamp($Pref::Client::CustomChat::EnableBuzzwords, 0, 1));
	CC_BuzzwordsListInput.setValue($Pref::Client::CustomChat::NotifyWhenSaid);
	CC_BuzzwordNotificationSoundInput.setValue($Pref::Client::CustomChat::NotifySoundFilename);

	CC_EnableAdminRanksCheck.setValue(mClamp($Pref::Client::CustomChat::EnableRanks, 0, 1));
	CC_AdminRankStringInput.setValue(escapeColorChars($Pref::Client::CustomChat::AdminRankString));
	CC_SuperAdminRankStringInput.setValue(escapeColorChars($Pref::Client::CustomChat::SuperAdminRankString));
	CC_HostRankStringInput.setValue(escapeColorChars($Pref::Client::CustomChat::HostRankString));

	for(%i=0;%i<3;%i++) {
		%obj = "CC_TimestampModeSetting" @ %i;
		%obj.setValue($Pref::Client::CustomChat::TimestampMode == %i ? 1 : 0);
	}
	%window.tsModeSetting = $Pref::Client::CustomChat::TimestampMode;
	for(%i=0;%i<3;%i++) {
		%obj = "CC_TimestampFormatSetting" @ %i;
		%obj.setValue($Pref::Client::CustomChat::HourMode == %i ? 1 : 0);
	}
	%window.tsFormatSetting = $Pref::Client::CustomChat::HourMode;
	CC_TimestampSecondsCheck.setValue(mClamp($Pref::Client::CustomChat::ShowSecondsInTimestamp, 0, 1));
	CC_TimestampColorBox.mColor = HexToRGB($Pref::Client::CustomChat::TimestampColor) SPC "255";

	CC_EnableSwearFilteringCheck.setValue(mClamp($Pref::Client::CustomChat::EnableSwearFiltering, 0, 1));
	CC_SwearFilterInput.setValue(escapeColorChars($Pref::Client::CustomChat::SwearList));
	CC_EnableAutoPunctuationCheck.setValue(mClamp($Pref::Client::CustomChat::EnableAutoPunctuation, 0, 1));

	CC_CustomStringsCheck.setValue(mClamp($Pref::Client::CustomChat::EnableCustomString, 0, 1));
	CC_CustomStringInput.setValue(escapeColorChars($Pref::Client::CustomChat::CustomChatString));
	$CustomChat::StringData = $Pref::Client::CustomChat::CustomChatString;

	// v0.4.0
	CC_FontFamilyInput_WT.setValue($Pref::Client::CustomChat::FontFamily_WT);
	CC_FontSizeInput_WT.setValue(mClamp($Pref::Client::CustomChat::FontSize_WT, 4, 64));
	CC_TextColorBox_WT.mColor = $Pref::Client::CustomChat::TextColor_WT;

	CC_TextOutlinesCheck_WT.setValue(mClamp($Pref::Client::CustomChat::EnableOutline_WT, 0, 1));
	CC_OutlineColorBox_WT.mColor = $Pref::Client::CustomChat::OutlineColor_WT;

	CC_TextShadowsCheck_WT.setValue(mClamp($Pref::Client::CustomChat::EnableShadow_WT, 0, 1));
	CC_ShadowColorBox_WT.mColor = HexToRGB($Pref::Client::CustomChat::ShadowColor_WT) SPC "255";
	CC_ShadowXInput_WT.setValue(mFloor($Pref::Client::CustomChat::ShadowX_WT));
	CC_ShadowYInput_WT.setValue(mFloor($Pref::Client::CustomChat::ShadowY_WT));
}

function openCustomChatSettings() {
	canvas.pushDialog("CustomChatSettingsGui");
	revertCustomChatSettings();
	switchCCTab("Appearance");
}

function saveCustomChatSettings() {
	for(%i=0;%i<10;%i++) {
		%obj = "CC_EscapeColorBox" @ %i;
		$Pref::Client::CustomChat::Color[%i] = %obj.mColor;
	}

	// i'll figure out some way to make this more dynamic at a later time
	for(%i=0;%i<10;%i++) {
		%obj = "CC_RandomNameColorBox" @ %i;
		$Pref::Client::CustomChat::RandomNameColor[%i] = CC_RGBToHex(getWords(%obj.mColor, 0, 2));
	}

	%window = CustomChatWindow;

	$Pref::Client::CustomChat::FontFamily = CC_FontFamilyInput.getValue();
	$Pref::Client::CustomChat::FontSize = mClamp(CC_FontSizeInput.getValue(), 4, 64);
	CC_FontSizeInput.setValue($Pref::Client::CustomChat::FontSize);

	$Pref::Client::CustomChat::LinkColor = CC_LinkColorBox.mColor;
	$Pref::Client::CustomChat::LinkVisitedColor = CC_LinkVisitedColorBox.mColor;

	$Pref::Client::CustomChat::EnableOutline = CC_TextOutlinesCheck.getValue();
	$Pref::Client::CustomChat::OutlineColor = CC_OutlineColorBox.mColor;

	$Pref::Client::CustomChat::EnableShadow = CC_TextShadowsCheck.getValue();
	$Pref::Client::CustomChat::ShadowColor = CC_RGBToHex(CC_ShadowColorBox.mColor);
	$Pref::Client::CustomChat::ShadowX = CC_ShadowXInput.getValue();
	$Pref::Client::CustomChat::ShadowY = CC_ShadowYInput.getValue();

	$Pref::Client::CustomChat::EnableChatBackground = CC_ChatBackgroundCheck.getValue();
	$Pref::Client::CustomChat::BackgroundWidth = CC_ChatBackgroundWidthInput.getValue();
	$Pref::Client::CustomChat::BackgroundX = CC_ChatBackgroundXInput.getValue();
	$Pref::Client::CustomChat::BackgroundY = CC_ChatBackgroundYInput.getValue();
	$Pref::Client::CustomChat::BackgroundColor = CC_ChatBackgroundColorBox.mColor;

	$Pref::Client::CustomChat::RemoveFontTags = CC_StripFontTagCheck.getValue();
	$Pref::Client::CustomChat::RemoveColorTags = CC_StripColorTagCheck.getValue();
	$Pref::Client::CustomChat::RemoveBitmapTags = CC_StripBitmapTagCheck.getValue();

	$Pref::Client::CustomChat::MaxBitmapHeight = CC_MaxBitmapHeightInput.getValue();

	$Pref::Client::CustomChat::NameColor = CC_RGBToHex(getWords(CC_NameColorBox.mColor, 0, 2));
	$Pref::Client::CustomChat::SelfNameColor = CC_RGBToHex(getWords(CC_SelfNameColorBox.mColor, 0, 2));
	$Pref::Client::CustomChat::EnableRandomNameColors = CC_RandomizeNameColorsCheck.getValue();
	$Pref::Client::CustomChat::EnableSlayerNameColors = CC_SlayerOverrideColorsCheck.getValue();

	$Pref::Client::CustomChat::EnableClanTags = CC_ClanTagsCheck.getValue();
	$Pref::Client::CustomChat::ClanTagsColor = CC_RGBToHex(getWords(CC_ClanTagColorBox.mColor, 0, 2));

	$Pref::Client::CustomChat::MessageColor = CC_RGBToHex(getWords(CC_MessageColorBox.mColor, 0, 2));
	$Pref::Client::CustomChat::SelfMsgColor = CC_RGBToHex(getWords(CC_SelfMessageColorBox.mColor, 0, 2));

	$Pref::Client::CustomChat::LogMode = %window.loggingMode;
	$Pref::Client::CustomChat::LogDir = CC_LogDirInput.getValue();
	$Pref::Client::CustomChat::StripMLControlChars = CC_StripMLCheck.getValue();
	$Pref::Client::CustomChat::EchoChatToConsole = CC_EchoChatCheck.getValue();

	$Pref::Client::CustomChat::SoundNotificationMode = %window.msgSoundSetting;
	$Pref::Client::CustomChat::EnableBuzzwords = CC_EnableBuzzwordsCheck.getValue();
	$Pref::Client::CustomChat::NotifyWhenSaid = CC_BuzzwordsListInput.getValue();
	$Pref::Client::CustomChat::NotifySoundFilename = CC_BuzzwordNotificationSoundInput.getValue();

	$Pref::Client::CustomChat::EnableRanks = CC_EnableAdminRanksCheck.getValue();
	$Pref::Client::CustomChat::AdminRankString = collapseEscape(CC_AdminRankStringInput.getValue());
	$Pref::Client::CustomChat::SuperAdminRankString = collapseEscape(CC_SuperAdminRankStringInput.getValue());
	$Pref::Client::CustomChat::HostRankString = collapseEscape(CC_HostRankStringInput.getValue());

	$Pref::Client::CustomChat::TimestampMode = %window.tsModeSetting;
	$Pref::Client::CustomChat::HourMode = %window.tsFormatSetting;
	$Pref::Client::CustomChat::ShowSecondsInTimestamp = CC_TimestampSecondsCheck.getValue();
	$Pref::Client::CustomChat::TimestampColor = CC_RGBToHex(getWords(CC_TimestampColorBox.mColor, 0, 2));

	$Pref::Client::CustomChat::EnableCustomString = CC_CustomStringsCheck.getValue();
	$Pref::Client::CustomChat::CustomChatString = $CustomChat::StringData = collapseEscape(CC_CustomStringInput.getValue());

	%msgSoundFilename = CC_NewMsgSoundInput.getValue();
	if(%msgSoundFilename !$= $Pref::Client::CustomChat::MessageSoundFilename) {
		if(isObject(CustomChatMsgNotify)) {
			CustomChatMsgNotify.delete();
			
			new AudioProfile(CustomChatMsgNotify) {
				fileName = %msgSoundFilename;
				description = AudioGui;
				preload = true;
			};
		}
	}
	$Pref::Client::CustomChat::MessageSoundFilename = %msgSoundFilename;

	%sentMsgSoundFilename = CC_SentMsgSoundInput.getValue();
	if(%sentMsgSoundFilename !$= $Pref::Client::CustomChat::SelfMessageSoundFilename) {
		if(isObject(CustomChatSelfMsgNotify)) {
			CustomChatSelfMsgNotify.delete();
			
			new AudioProfile(CustomChatSelfMsgNotify) {
				fileName = %sentMsgSoundFilename;
				description = AudioGui;
				preload = true;
			};
		}
	}
	$Pref::Client::CustomChat::SelfMessageSoundFilename = CC_SentMsgSoundInput.getValue();

	$Pref::Client::CustomChat::EnableSwearFiltering = CC_EnableSwearFilteringCheck.getValue();
	$Pref::Client::CustomChat::SwearList = CC_SwearFilterInput.getValue();
	$Pref::Client::CustomChat::EnableAutoPunctuation = CC_EnableAutoPunctuationCheck.getValue();

	messageBoxOK("", "Chat settings were saved.");

	updateFontFamily($Pref::Client::CustomChat::FontFamily);
	updateFontSize($Pref::Client::CustomChat::FontSize);
	updateLinkColor($Pref::Client::CustomChat::LinkColor);
	updateVisitedLinkColor($Pref::Client::CustomChat::LinkVisitedColor);
	setChatTextOutline($Pref::Client::CustomChat::EnableOutline);
	setChatTextOutlineColor($Pref::Client::CustomChat::OutlineColor);

	if($Pref::Client::CustomChat::EnableChatBackground) {
		updateChatBoxColor($Pref::Client::CustomChat::BackgroundColor);
		%b_x = $Pref::Client::CustomChat::BackgroundX;
		%b_y = $Pref::Client::CustomChat::BackgroundY;
		%b_w = $Pref::Client::CustomChat::BackgroundWidth;
		resizeChatBox(%b_x, %b_y, %b_w);
	} else {
		updateChatBoxColor("0 0 0 0");
	}

	NewChatText.setProfile(BlockChatTextSize1Profile);
	setChatColors();

	NewChatText.MaxBitmapHeight = $Pref::Client::CustomChat::MaxBitmapHeight;

	//v0.4.0
	$Pref::Client::CustomChat::FontFamily_WT = CC_FontFamilyInput_WT.getValue();
	$Pref::Client::CustomChat::FontSize_WT = mClamp(CC_FontSizeInput_WT.getValue(), 4, 64);
	CC_FontSizeInput_WT.setValue($Pref::Client::CustomChat::FontSize_WT);
	$Pref::Client::CustomChat::TextColor_WT = CC_TextColorBox_WT.mColor;

	$Pref::Client::CustomChat::EnableOutline_WT = CC_TextOutlinesCheck_WT.getValue();
	$Pref::Client::CustomChat::OutlineColor_WT = CC_OutlineColorBox_WT.mColor;

	$Pref::Client::CustomChat::EnableShadow_WT = CC_TextShadowsCheck_WT.getValue();
	$Pref::Client::CustomChat::ShadowColor_WT = CC_RGBToHex(CC_ShadowColorBox_WT.mColor);
	$Pref::Client::CustomChat::ShadowX_WT = CC_ShadowXInput_WT.getValue();
	$Pref::Client::CustomChat::ShadowY_WT = CC_ShadowYInput_WT.getValue();

	updateFontFamily_WT($Pref::Client::CustomChat::FontFamily_WT);
	updateFontSize_WT($Pref::Client::CustomChat::FontSize_WT);
	updateTextColor_WT($Pref::Client::CustomChat::TextColor_WT);
	setChatTextOutline_WT($Pref::Client::CustomChat::EnableOutline_WT);
	setChatTextOutlineColor_WT($Pref::Client::CustomChat::OutlineColor_WT);
}

function switchCCTab(%tab) {
	%obj = "ChatSettings" @ %tab @ "Pane";
	if(!isObject(%obj)) {
		return;
	}

	ChatSettingsAppearancePane.setVisible(%tab $= "Appearance" ? 1 : 0);
	ChatSettingsSoundPane.setVisible(%tab $= "Sound" ? 1 : 0);
	ChatSettingsLoggingPane.setVisible(%tab $= "Logging" ? 1 : 0);
	ChatSettingsExtraPane.setVisible(%tab $= "Extra" ? 1 : 0);

	CustomChatWindow.bringToFront(%obj);

	CustomChatWindow.setText("Chat Settings -" SPC %tab);
}


function setCCLoggingSetting(%value) {
	%window = CustomChatWindow;
	%window.loggingMode = mClamp(%value, 0, 2);
}


function setCCMessageSoundSetting(%value) {
	%window = CustomChatWindow;
	%window.msgSoundSetting = mClamp(%value, 0, 2);
}


function setCCTimestampModeSetting(%value) {
	%window = CustomChatWindow;
	%window.tsModeSetting = mClamp(%value, 0, 2);
}
function setCCTimestampFormatSetting(%value) {
	%window = CustomChatWindow;
	%window.tsFormatSetting = mClamp(%value, 0, 2);
}


function openCustomChatColorChooser(%name, %box, %hex, %alpha) {
	%value = %box.mColor;

	canvas.pushDialog("CustomChatColorGui");
	%window = CustomChatColorChooserWindow;

	%window.setText("Setting color for" SPC %name);
	%window.activeBox = %box;

	if(%hex) {
		CustomChatColorChooserHexArea.setVisible(1);
		CustomChatColorChooserHex.setText("<font:Arial Bold:14><color:ffffff><just:center>#" @ strUpr(CC_RGBToHex(%value)));
		%window.isHex = 1;
	} else {
		CustomChatColorChooserHexArea.setVisible(0);
		%window.isHex = 0;
	}

	if(%alpha) {
		CustomChatColorChooserAlphaSlider.setVisible(1);
		CustomChatColorChooserAlphaSlider.setValue(getWord(%value, 3));
		%window.isAlpha = 1;
	} else {
		CustomChatColorChooserAlphaSlider.setVisible(0);
		%window.isAlpha = 0;
	}

	CustomChatColorChooserRedSlider.setValue(getWord(%value, 0));
	CustomChatColorChooserGreenSlider.setValue(getWord(%value, 1));
	CustomChatColorChooserBlueSlider.setValue(getWord(%value, 2));

	updateCCColor();
}

function CCC_sliderUpdate(%slider) {
	%slider.setValue(mFloor(%slider.getValue()));
	updateCCColor();
}

function updateCCColor(%red, %green, %blue, %alpha) {
	%window = CustomChatColorChooserWindow;

	if(%red $= "") {
		%red = CustomChatColorChooserRedSlider.getValue();
		%green = CustomChatColorChooserGreenSlider.getValue();
		%blue = CustomChatColorChooserBlueSlider.getValue();
		%alpha = CustomChatColorChooserAlphaSlider.getValue();
	}

	%value = %red SPC %green SPC %blue SPC (%window.isAlpha ? CustomChatColorChooserAlphaSlider.getValue() : 255);
	CustomChatColorChooserBox.color = %value;

	if(%window.isHex) {
		if(%window.isAlpha) {
			CustomChatColorChooserBox.color = %value;
			%value = CC_RGBToHex(%value);
		} else {
			%value = CC_RGBToHex(%red SPC %green SPC %blue);
			CustomChatColorChooserBox.color = %red SPC %green SPC %blue SPC "255";
		}

		CustomChatColorChooserHex.setText("<font:Arial Bold:14><color:ffffff><just:center>#" @ strUpr(%value));
	} else {
		CustomChatColorChooserBox.color = %value;
	}
}

function selectCCColor() {
	%window = CustomChatColorChooserWindow;

	%red = CustomChatColorChooserRedSlider.getValue();
	%green = CustomChatColorChooserGreenSlider.getValue();
	%blue = CustomChatColorChooserBlueSlider.getValue();

	%value = %red SPC %green SPC %blue SPC (%window.isAlpha ? CustomChatColorChooserAlphaSlider.getValue() : 255);
	%window.activeBox.mColor = %value;

	canvas.popDialog(CustomChatColorGui);
}

function randomizeCCColor() {
	%red = getRandom(0, 255);
	%green = getRandom(0, 255);
	%blue = getRandom(0, 255);
	%alpha = getRandom(0, 255);

	updateCCColor(%red, %green, %blue, %alpha);

	CustomChatColorChooserRedSlider.setValue(%red);
	CustomChatColorChooserGreenSlider.setValue(%green);
	CustomChatColorChooserBlueSlider.setValue(%blue);
	CustomChatColorChooserBlueSlider.setValue(%alpha);
}