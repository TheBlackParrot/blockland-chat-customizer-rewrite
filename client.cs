// TODO:
//	- allow BL_ID's to be shown
//		- i'd prefer another cache method like i'm doing with ranks, load needs to be reduced as much as possible
//		- as much as i don't want to turn this into some datamining thing, i can save BL_ID/name details to files and just load them as needed in globals
//			- based off experiments with my markov bot saving its corpus to individual files, this is a bad idea
//	- GUI
//	O remove forced defaulting of variables (see globals below)
//	O restore variables to default values
//	O place custom default values in DEFAULTS.json
//	- figure out how to detect if a server is running, and force echoing chat to the console off client-sided so chat isn't repeated
//	? switch to a dynamic format, e.g.
//		- "t [r] n: m"
//		- "t [r] cPncS: m"
//		- "[t] [r] [id] cPn: m"
//	? presets
//	- rework "buzzwords" not to use fields, actually use words lol
//	? better censoring
//	? background color
//		- newChatHud is an auto-reisizing MLTextCtrl object, this might involve giving it a parent SwatchCtrl

// note the todo list is now moreso an idea list


if(!isObject(ChatLogFileObject)) {
	new FileObject(ChatLogFileObject);
}

if($Pref::Client::CustomChat::MessageSoundFilename $= "") {
	$Pref::Client::CustomChat::MessageSoundFilename = "./sounds/msg.wav";
	$Pref::Client::CustomChat::SelfMessageSoundFilename = "./sounds/selfmsg.wav";
	$Pref::Client::CustomChat::NotifySoundFilename = "./sounds/notify.wav";
}

exec("./sounds.cs");
exec("./support.cs");
exec("./overrides.cs");
exec("./wrappers.cs");
exec("./gui.cs");
exec("./string.cs");

if($Pref::Client::CustomChat::SoundNotificationMode $= "") {
	// 0 = off, 1 = non-self messages, 2 = all chat messages
	$Pref::Client::CustomChat::SoundNotificationMode = 0;

	// see DEFAULTS.json for default values
	$Pref::Client::CustomChat::Color0 = "255 0 64 255";
	$Pref::Client::CustomChat::Color1 = "64 64 255 255";
	$Pref::Client::CustomChat::Color2 = "0 255 0 255";
	$Pref::Client::CustomChat::Color3 = "255 255 0 255";
	$Pref::Client::CustomChat::Color4 = "0 255 255 255";
	$Pref::Client::CustomChat::Color5 = "255 0 255 255";
	$Pref::Client::CustomChat::Color6 = "255 255 255 255";
	$Pref::Client::CustomChat::Color7 = "96 96 96 255";
	$Pref::Client::CustomChat::Color8 = "0 0 0 0";
	$Pref::Client::CustomChat::Color9 = "0 0 0 0";

	$Pref::Client::CustomChat::FontFamily = "Palatino Linotype";
	$Pref::Client::CustomChat::FontSize = 24;

	$Pref::Client::CustomChat::LinkColor = "0 255 255 255";
	$Pref::Client::CustomChat::LinkVisitedColor = "255 0 255 255";

	$Pref::Client::CustomChat::EnableOutline = 1;
	$Pref::Client::CustomChat::OutlineColor = "0 0 0 255";

	$Pref::Client::CustomChat::EnableShadow = 0;
	$Pref::Client::CustomChat::ShadowX = 2;
	$Pref::Client::CustomChat::ShadowY = 2;
	$Pref::Client::CustomChat::ShadowColor = "00000099";

	// 0 = off, 1 = chat only, 2 = all messages
	$Pref::Client::CustomChat::LogMode = 0;
	$Pref::Client::CustomChat::LogDir = "config/client/chat/logs/";
	// 0 = leave formatting things in chat logs, 1 = text only
	$Pref::Client::CustomChat::StripMLControlChars = 1;

	$Pref::Client::CustomChat::NameColor = "FFFF00";
	$Pref::Client::CustomChat::SelfNameColor = "FFFF00";
	$Pref::Client::CustomChat::EnableRandomNameColors = 0;
	$Pref::Client::CustomChat::RandomNameColor0 = "FFAAAA"; // red
	$Pref::Client::CustomChat::RandomNameColor1 = "FFCCAA"; // orange
	$Pref::Client::CustomChat::RandomNameColor2 = "FFFFAA"; // yellow
	$Pref::Client::CustomChat::RandomNameColor3 = "CCFFAA"; // yellow green
	$Pref::Client::CustomChat::RandomNameColor4 = "AAFFAA"; // green
	$Pref::Client::CustomChat::RandomNameColor5 = "AAFFFF"; // cyan
	$Pref::Client::CustomChat::RandomNameColor6 = "AACCFF"; // sky blue
	$Pref::Client::CustomChat::RandomNameColor7 = "AAAAFF"; // blue
	$Pref::Client::CustomChat::RandomNameColor8 = "CCAAFF"; // purple
	$Pref::Client::CustomChat::RandomNameColor9 = "FFAAFF"; // pink
	$Pref::Client::CustomChat::RandomNameColorCount = 10;

	$Pref::Client::CustomChat::EnableClanTags = 1;
	$Pref::Client::CustomChat::ClanTagsColor = "606060";

	$Pref::Client::CustomChat::MessageColor = "FFFFFF";
	$Pref::Client::CustomChat::SelfMsgColor = "FFFFFF";

	// 0 = off, 1 = chat only, 2 = all messages
	$Pref::Client::CustomChat::TimestampMode = 0;
	// 0 = 24 hour, 1 = 12 hour (AM/PM)
	$Pref::Client::CustomChat::HourMode = 1;
	$Pref::Client::CustomChat::ShowSecondsInTimestamp = 0;
	$Pref::Client::CustomChat::TimestampColor = "99FF00";

	$Pref::Client::CustomChat::EnableRanks = 0;
	$Pref::Client::CustomChat::AdminRankString = "\c7[\c2A\c7]";
	$Pref::Client::CustomChat::SuperAdminRankString = "\c7[\c0S\c7]";

	$Pref::Client::CustomChat::RemoveFontTags = 0;
	$Pref::Client::CustomChat::RemoveColorTags = 0;

	$Pref::Client::CustomChat::EchoChatToConsole = 0;

	$Pref::Client::CustomChat::EnableBuzzwords = 0;
	$Pref::Client::CustomChat::NotifyWhenSaid = $pref::Player::NetName SPC $pref::Player::LANName;

	$Pref::Client::CustomChat::EnableSwearFiltering = 0;
	$Pref::Client::CustomChat::SwearList = "";

	$Pref::Client::CustomChat::EnableAutoPunctuation = 0;

	$Pref::Client::CustomChat::EnableCustomString = 0;
}

if(!$CustomChat::TotalMessages $= "") {
	$CustomChat::TotalMessages = 0;
}

// didn't exist pre v0.2.1-1
if($Pref::Client::CustomChat::HostRankString $= "") {
	$Pref::Client::CustomChat::HostRankString = "\c7[\c5H\c7]";
}

// didn't exist pre v0.3.0-1
if($Pref::Client::CustomChat::EnableChatBackground $= "") {
	$Pref::Client::CustomChat::EnableChatBackground = 0;
	// pre v0.4.0-dev update 2: value was 500
	$Pref::Client::CustomChat::BackgroundWidth = getWord(getRes(), 0);
	// pre v0.4.0-dev update 2: value was "0 0 0 128"
	$Pref::Client::CustomChat::BackgroundColor = "0 0 0 0";
	$Pref::Client::CustomChat::BackgroundX = "0";
	$Pref::Client::CustomChat::BackgroundY = "20";
}

// didn't exist pre v0.3.1-1
if($Pref::Client::CustomChat::RemoveBitmapTags $= "") {
	$Pref::Client::CustomChat::RemoveBitmapTags = 0;
	$Pref::Client::CustomChat::MaxBitmapHeight = 0;
}

// didn't exist pre v0.4.0-dev update 1
if($Pref::Client::CustomChat::FontFamily_WT $= "") {
	$Pref::Client::CustomChat::FontFamily_WT = "Arial";
	$Pref::Client::CustomChat::FontSize_WT = 14;
	$Pref::Client::CustomChat::TextColor_WT = "255 255 255 255";
	$Pref::Client::CustomChat::EnableOutline_WT = 1;
	$Pref::Client::CustomChat::OutlineColor_WT = "32 32 255 255";
	$Pref::Client::CustomChat::EnableShadow_WT = 0;
	$Pref::Client::CustomChat::ShadowColor_WT = "0 0 0 128";
	$Pref::Client::CustomChat::ShadowX_WT = 1;
	$Pref::Client::CustomChat::ShadowY_WT = 1;
}

// force fix on new background mode in v0.4.0-dev update 2
if($Pref::Client::CustomChat::NewPositioning $= "") {
	$Pref::Client::CustomChat::NewPositioning = "ignore this";

	if(!$Pref::Client::CustomChat::EnableChatBackground && $Pref::Client::CustomChat::BackgroundWidth == 500 && $Pref::Client::CustomChat::BackgroundColor $= "0 0 0 128") {
		// never used a background, go ahead and reset the variable to the correct width since we're using this all the time now
		$Pref::Client::CustomChat::BackgroundWidth = getWord(getRes(), 0);
		$Pref::Client::CustomChat::BackgroundColor = "0 0 0 0";
	}
}

updateFontFamily($Pref::Client::CustomChat::FontFamily);
updateFontSize($Pref::Client::CustomChat::FontSize);

updateLinkColor($Pref::Client::CustomChat::LinkColor);
updateVisitedLinkColor($Pref::Client::CustomChat::LinkVisitedColor);

setChatTextOutline($Pref::Client::CustomChat::EnableOutline);
setChatTextOutlineColor($Pref::Client::CustomChat::OutlineColor);

updateFontFamily_WT($Pref::Client::CustomChat::FontFamily_WT);
updateFontSize_WT($Pref::Client::CustomChat::FontSize_WT);
updateTextColor_WT($Pref::Client::CustomChat::TextColor_WT);

setChatTextOutline_WT($Pref::Client::CustomChat::EnableOutline_WT);
setChatTextOutlineColor_WT($Pref::Client::CustomChat::OutlineColor_WT);

// Taking over BlockChatTextSize1Profile and forcing it
// I find it interesting that font sizes don't actually change just by doing this
NewChatText.setProfile(BlockChatTextSize1Profile);
NMH_Channel.setText("");
NMH_Channel.setVisible(0);
NMH_Type.setProfile(HudChatTextEditSize1Profile);
NMH_Type.position = "0 0";

setChatColors();

NewChatText.MaxBitmapHeight = $Pref::Client::CustomChat::MaxBitmapHeight;

// TODO: Make a time lib (attempt to port over as much as possible from http://php.net/manual/en/function.date.php)
function getChatTimestamp() {
	if($Pref::Client::CustomChat::HourMode < 2) {
		%time = getWord(getDateTime(), 1);

		%hour = getSubStr(%time, 0, 2);
		%mins = getSubStr(%time, 3, 2);
		%secs = "";
		if($Pref::Client::CustomChat::ShowSecondsInTimestamp) {
			%secs = ":" @ getSubStr(%time, 6, 2);
		}
		%meridiem = "";

		if(!$Pref::Client::CustomChat::HourMode) {
			%meridiem = " AM";

			if(%hour > 12) {
				%hour -= 12;
				%meridiem = " PM";
			}
			if(!%hour) {
				%hour = 12;
			}
		}

		return %hour @ ":" @ %mins @ %secs @ %meridiem;
	}

	return getUTC();
}

function cachePlayerData(%forceReload) {
	%list = NPL_List;

	if(%list.rowCount() != $CustomChat::PreviousCount || %forceReload !$= "") {
		$CustomChat::PreviousCount = %list.rowCount();

		deleteVariables("$CustomChat::IsAdmin*");
		deleteVariables("$CustomChat::IsSuperAdmin*");

		for(%i=0;%i<%list.rowCount();%i++) {
			%row = %list.getRowText(%i);

			%rank = stripMLControlChars(getField(%row, 0));
			%name = stripMLControlChars(getField(%row, 1));

			$CustomChat::PlayerNameBLID[%name] = stripMLControlChars(getField(%row, 3));

			switch$(%rank) {
				case "A": $CustomChat::Admins = $CustomChat::IsAdmin[%name] = 1;
				case "S": $CustomChat::SuperAdmins = $CustomChat::IsSuperAdmin[%name] = 1;
			}
		}
	}
}

function isUserRanked(%who, %forceReload) {
	cachePlayerData(%forceReload);

	if(strStr(getField($CustomChat::CurrentServer, 2), %who) != -1) {
		return 3;
	}
	if(isObject(MissionCleanup)) {
		if(%who $= $pref::Player::NetName) {
			return 3;
		}
	}
	if($CustomChat::IsAdmin[%name]) {
		return 1;
	}
	if($CustomChat::IsSuperAdmin[%name]) {
		return 2;
	}

	return 0;
}

function getRandomNameColor(%name) {
	%sha1 = sha1(%name);
	
	%chars = "0123456789abcdef";

	for(%i=0;%i<4;%i++) {
		%sum += stripos(%chars, getSubStr(%sha1, %i, 1));
	}

	return $Pref::Client::CustomChat::RandomNameColor[%sum % $Pref::Client::CustomChat::RandomNameColorCount];
}

function logChat(%fileObj, %name, %msg) {
	%date = getDateTime();
	%sanitizedDate = getWord(strReplace(%date, "/", "-"), 0);

	if($Pref::Client::CustomChat::StripMLControlChars) {
		%msg = stripMLControlChars(%msg);
	}

	%fileObj.openForAppend($Pref::Client::CustomChat::LogDir @ %sanitizedDate @ ".log");

	%fileObj.writeLine(%date TAB %name TAB ($CustomChat::PlayerNameBLID[%name] $= "" ? "-1" : $CustomChat::PlayerNameBLID[%name]) TAB %msg);

	%fileObj.close();
}

function sanitizeBitmapTags(%string) {
	while(stripos(%string, "<bitmap:") != -1) {
		%start = stripos(%string, "<bitmap:");
		%end = stripos(%string, ">", %start)+1;
		
		%toRemove = getSubStr(%string, %start, %end - %start);

		%string = strReplace(%string, %toRemove, "");
	}

	return %string;
}

function sanitizeFontTags(%string) {
	while(stripos(%string, "<font:") != -1) {
		%start = stripos(%string, "<font:");
		%end = stripos(%string, ">", %start)+1;
		
		%toRemove = getSubStr(%string, %start, %end - %start);

		%string = strReplace(%string, %toRemove, "");
	}

	return %string;
}

function sanitizeColorTags(%string) {
	while(stripos(%string, "<color:") != -1) {
		%start = stripos(%string, "<color:");
		%end = stripos(%string, ">", %start)+1;
		
		%toRemove = getSubStr(%string, %start, %end - %start);

		%string = strReplace(%string, %toRemove, "");
	}

	return stripChars(%string, "\c0\c1\c2\c3\c4\c5\c6\c7\c8\c9");
}

package CustomChatPackage {
	function clientCmdServerMessage(%tag, %fmsg, %clanPrefix, %name, %clanSuffix, %msg, %a, %b, %idk, %d, %e, %f) {
		%taggedStringName = stripMLControlChars(getTaggedString(getWord(%tag, 0)));
		if(%taggedStringName $= "chatMessage") {
			if(getWord(stripMLControlChars(trim(%idk)), 0) $= "[DEAD]") {
				clientCmdChatMessage(0, 0, 0, %fmsg, %clanPrefix, %name, %clanSuffix SPC "\c7[DEAD]", %msg);
				return;
			}
		}

		if(%taggedStringName $= "MsgAdminForce" || %taggedStringName $= "MsgClientJoin") {
			cachePlayerData(1);
		}

		if(%taggedStringName $= "MsgStartTalking") {

		}

		return parent::clientCmdServerMessage(%tag, %fmsg, %clanPrefix, %name, %clanSuffix, %msg, %a, %b, %idk, %d, %e, %f);
	}
	function clientCmdChatMessage(%a, %b, %c, %fmsg, %clanPrefix, %name, %clanSuffix, %msg, %color) {
		// %color is for slayer
		%soundMode = $Pref::Client::CustomChat::SoundNotificationMode;

		%taggedString = stripMLControlChars(getTaggedString(getWord(%fmsg, 0)));
		switch$(%taggedString) {
			case "%1%2%3: %4" or "%1%2%3%7: %4" or "%1%5%2%3%7: %4" or "%5%1%2%5%3%7: %4" or "[%5%6] %1%2%3%7: %4":
				%isChatMsg = 1;
		}
		if(!%isChatMsg) {
			// isn't a chat message
			return parent::clientCmdChatMessage(%a, %b, %c, %fmsg, %clanPrefix, %name, %clanSuffix, %msg);
		}

		$CustomChat::TotalMessages++;

		%slayerDot = "";
		if(%taggedString $= "%1%5%2%3%7: %4") {
			if($Pref::Client::CustomChat::EnableSlayerNameColors) {
				%forcedColor = %color;
				%forceAllowColor = 1;
			} else {
				%slayerDot = %color @ "== ";
			}
		}

		// might as well do this before everything
		if($Pref::Client::CustomChat::RemoveFontTags
		&& $Pref::Client::CustomChat::RemoveColorTags
		&& $Pref::Client::CustomChat::RemoveBitmapTags) {
			%fmsg = stripMLControlChars(%fmsg);

			if($Pref::Client::CustomChat::EnableClanTags) {
				%clanPrefix = stripMLControlChars(%clanPrefix);
				%clanSuffix = stripMLControlChars(%clanSuffix);
			}
		} else {
			if($Pref::Client::CustomChat::RemoveFontTags) {
				%fmsg = sanitizeFontTags(%fmsg);
				%name = sanitizeFontTags(%name);
				%msg = sanitizeFontTags(%msg);

				if($Pref::Client::CustomChat::EnableClanTags) {
					%clanPrefix = sanitizeFontTags(%clanPrefix);
					%clanSuffix = sanitizeFontTags(%clanSuffix);
				}
			}

			if(!%forceAllowColor) {
				if($Pref::Client::CustomChat::RemoveColorTags) {
					%fmsg = sanitizeColorTags(%fmsg);
					%name = sanitizeColorTags(%name);
					%msg = sanitizeColorTags(%msg);

					if($Pref::Client::CustomChat::EnableClanTags) {
						%clanPrefix = sanitizeColorTags(%clanPrefix);
						%clanSuffix = sanitizeColorTags(%clanSuffix);
					}
				}
			}
		}

		if($Pref::Client::CustomChat::EchoChatToConsole) {
			// this seems to work for preventing duplicate messages
			if(!isObject(MissionCleanup)) {
				echo(stripMLControlChars(%name @ ":" SPC %msg));
			}
		}

		if($Pref::Client::CustomChat::LogMode >= 1) {
			logChat(ChatLogFileObject, %name, %msg);
			$CustomChat::PreventLogOddity = 1;
		}

		if(stripMLControlChars(%name) $= $pref::Player::NetName || stripMLControlChars(%name) $= $pref::Player::LANName) {
			if(%soundMode == 2) {
				alxPlay(CustomChatSelfMsgNotify);
			}
		} else {
			if(%soundMode >= 1) {
				alxPlay(CustomChatMsgNotify);
			}
		}

		if($Pref::Client::CustomChat::EnableBuzzwords) {
			%buzzwords = $Pref::Client::CustomChat::NotifyWhenSaid;
			for(%i=0;%i<getWordCount(%buzzwords);%i++) {
				if(stripos(%msg, getWord(%buzzwords, %i)) != -1) {
					alxPlay(CustomChatNotifySound);
					break;
				}
			}
		}

		if($Pref::Client::CustomChat::EnableAutoPunctuation) {
			%msg = CC_autoPunctuateString(%msg);
		}

		if($Pref::Client::CustomChat::EnableCustomString || $CustomChat::ForceString) {
			%all = CC_getCustomChatString(%clanPrefix, %name, %clanSuffix, %msg, %color);
			%fmsg = getWord(%fmsg, 0) SPC %all;

			if($CustomChat::Debug) {
				NewChatSO.addLine($Pref::Client::CustomChat::CustomChatString);
			}
			return parent::clientCmdChatMessage(%a, %b, %c, %fmsg, %clanPrefix, %name, %clanSuffix, %msg);
		}


		// IF CUSTOM STRING IS DISABLED: FALLBACK TO OLD SYSTEM


		%rank = "";
		if($Pref::Client::CustomChat::EnableRanks) {
			switch(isUserRanked(%name)) {
				case 1: %rank = $Pref::Client::CustomChat::AdminRankString @ " ";
				case 2: %rank = $Pref::Client::CustomChat::SuperAdminRankString @ " ";
				case 3: %rank = $Pref::Client::CustomChat::HostRankString @ " ";
			}
		}

		if(stripMLControlChars(%name) $= $pref::Player::NetName || stripMLControlChars(%name) $= $pref::Player::LANName) {
			if(!%forceAllowColor) {
				%name = "<color:" @ $Pref::Client::CustomChat::SelfNameColor @ ">" @ %name;
			}
			%preMsg = "<color:" @ $Pref::Client::CustomChat::SelfMsgColor @ ">";
		} else {
			if(!%forceAllowColor) {
				if(!$Pref::Client::CustomChat::EnableRandomNameColors) {
					%name = "<color:" @ $Pref::Client::CustomChat::NameColor @ ">" @ %name;
				} else {
					// random name colors are actually psuedo-random (shhhh)
					%name = "<color:" @ getRandomNameColor(%name) @ ">" @ %name;
				}
			}

			%preMsg = "<color:" @ $Pref::Client::CustomChat::MessageColor @ ">";
		}

		if(!$Pref::Client::CustomChat::EnableClanTags) {
			%clanPrefix = "";
			%clanSuffix = "";
		} else {
			%clanPrefix = "<color:" @ $Pref::Client::CustomChat::ClanTagsColor @ ">" @ %clanPrefix;
			%clanSuffix = "<color:" @ $Pref::Client::CustomChat::ClanTagsColor @ ">" @ %clanSuffix;
		}

		%time = "";
		if($Pref::Client::CustomChat::TimestampMode == 1) {
			%time = "<color:" @ $Pref::Client::CustomChat::TimestampColor @ ">" @ getChatTimestamp() @ " ";
		}

		%fmsg = getWord(%fmsg, 0) SPC %time @ %rank @ %slayerDot @ %clanPrefix @ %forcedColor @ %name @ %clanSuffix @ %preMsg @ ":" SPC %msg;

		return parent::clientCmdChatMessage(%a, %b, %c, %fmsg, %clanPrefix, %name, %clanSuffix, %msg);
	}

	function NewChatSO::addLine(%this, %msg, %a, %b, %c) {
		if($Pref::Client::CustomChat::LogMode == 2) {
			if(!$CustomChat::PreventLogOddity) {
				logChat(ChatLogFileObject, "-", %msg);
			}
			$CustomChat::PreventLogOddity = 0;
		}

		%time = "";
		if($Pref::Client::CustomChat::TimestampMode == 2) {
			%time = "<color:" @ $Pref::Client::CustomChat::TimestampColor @ ">" @ getChatTimestamp() @ " ";
		}

		if($Pref::Client::CustomChat::EnableSwearFiltering) {
			%msg = CC_stripBadWords(%msg);
		}

		if($Pref::Client::CustomChat::RemoveBitmapTags) {
			%msg = sanitizeBitmapTags(%msg);
		}

		%pre = "";
		if($Pref::Client::CustomChat::EnableShadow) {
			%x = $Pref::Client::CustomChat::ShadowX;
			%y = $Pref::Client::CustomChat::ShadowY;
			%pre = %pre @ "<shadow:" @ %x @ ":" @ %y @ "><shadowcolor:" @ $Pref::Client::CustomChat::ShadowColor @ ">";

			// hhhhhhhhhh
			%msg = strReplace(%msg, "\c0", "<color:" @ CC_RGBToHex($Pref::Client::CustomChat::Color0) @ ">");
			%msg = strReplace(%msg, "\c1", "<color:" @ CC_RGBToHex($Pref::Client::CustomChat::Color1) @ ">");
			%msg = strReplace(%msg, "\c2", "<color:" @ CC_RGBToHex($Pref::Client::CustomChat::Color2) @ ">");
			%msg = strReplace(%msg, "\c3", "<color:" @ CC_RGBToHex($Pref::Client::CustomChat::Color3) @ ">");
			%msg = strReplace(%msg, "\c4", "<color:" @ CC_RGBToHex($Pref::Client::CustomChat::Color4) @ ">");
			%msg = strReplace(%msg, "\c5", "<color:" @ CC_RGBToHex($Pref::Client::CustomChat::Color5) @ ">");
			%msg = strReplace(%msg, "\c6", "<color:" @ CC_RGBToHex($Pref::Client::CustomChat::Color6) @ ">");
			%msg = strReplace(%msg, "\c7", "<color:" @ CC_RGBToHex($Pref::Client::CustomChat::Color7) @ ">");
			%msg = strReplace(%msg, "\c8", "<color:" @ CC_RGBToHex($Pref::Client::CustomChat::Color8) @ ">");
			%msg = strReplace(%msg, "\c9", "<color:" @ CC_RGBToHex($Pref::Client::CustomChat::Color9) @ ">");
		}

		// \cr wouldn't work. :(
		%r = parent::addLine(%this, %pre @ %time @ "<color:" @ CC_RGBToHex($Pref::Client::CustomChat::Color0) @ ">" @ %msg, %a, %b, %c);

		// oddly enough this isn't called by default
		newChatText.forceReflow();
		newMessageHud.updatePosition();

		return %r;
	}

	function newMessageHud::updatePosition(%this, %a, %b, %c) {
		parent::updatePosition(%this, %a, %b, %c);

		%extent = newChatText.getExtent();

		if(newChatText.getValue() $= "") {
			// pref for presistence
			$Pref::Client::CustomChat::CurrentBottomPad = getWord(%extent, 1);
		}

		%x = $Pref::Client::CustomChat::BackgroundX;
		%y = $Pref::Client::CustomChat::BackgroundY;
		%w = $Pref::Client::CustomChat::BackgroundWidth;

		CustomChatBackground.resize(%x, %y, %w, getWord(%extent, 1)-$Pref::Client::CustomChat::CurrentBottomPad);
		newChatText.resize(2, 0, %w-2, getWord(%extent, 1));
	}

	function disconnect(%a) {
		if($CustomChat::ForceString) {
			$CustomChat::ForceString = 0;
		}
		
		return parent::disconnect(%a);
	}

	function LoadingGui::onWake(%this) {
		parent::onWake(%this);

		// only thing i could think of :(
		$CustomChat::CurrentServer = JS_serverList.getRowTextByID(JS_serverList.getSelectedID());

		cachePlayerData(1);

		if($Pref::Client::CustomChat::EnableChatBackground) {
			updateChatBoxColor($Pref::Client::CustomChat::BackgroundColor);
		} else {
			updateChatBoxColor("0 0 0 0");
		}

		%b_x = $Pref::Client::CustomChat::BackgroundX;
		%b_y = $Pref::Client::CustomChat::BackgroundY;
		%b_w = $Pref::Client::CustomChat::BackgroundWidth;
		resizeChatBox(%b_x, %b_y, %b_w);

		NewChatText.MaxBitmapHeight = $Pref::Client::CustomChat::MaxBitmapHeight;

		newChatText.forceReflow();
		newMessageHud.updatePosition();
	}

	function optionsDlg::onWake(%this) {
		parent::onWake(%this);

		NewChatText.setProfile(BlockChatTextSize1Profile);
	}

	function newChatText::setProfile(%this, %profile) {
		if(stripos(%profile.getName(), "BlockChatTextSize") != -1) {
			%profile = BlockChatTextSize1Profile;
		}

		parent::setProfile(%this, %profile);

		// honestly what the hell is blockland doing here? i'm adding this everywhere because SOMETHING is resetting this to 24 and i can't trace it
		NewChatText.MaxBitmapHeight = $Pref::Client::CustomChat::MaxBitmapHeight;
	}

	function NMH_Type::setProfile(%this, %profile) {
		if(stripos(%profile.getName(), "HudChatTextEditSize") != -1) {
			%profile = HudChatTextEditSize1Profile;
		}

		parent::setProfile(%this, %profile);
	}

	function WhoTalkSO::Display(%this, %a, %b, %c) {
		%a = parent::Display(%this, %a, %b, %c);
		%text = stripMLControlChars(chatWhosTalkingText.getValue());

		if($Pref::Client::CustomChat::EnableShadow_WT) {
			%color = $Pref::Client::CustomChat::ShadowColor_WT;
			%x = $Pref::Client::CustomChat::ShadowX_WT;
			%y = $Pref::Client::CustomChat::ShadowY_WT;

			%pre = "<shadow:" @ %x @ ":" @ %y @ "><shadowcolor:" @ %color @ ">";
			
			chatWhosTalkingText.setValue(%pre @ %text);
		}
		return %a;
	}
};
activatePackage(CustomChatPackage);

$CustomChat::Version = "0.4.0-3";
echo("Executed Client_CustomChat v" @ $CustomChat::Version);