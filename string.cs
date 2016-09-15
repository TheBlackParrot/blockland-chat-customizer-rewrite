if($CustomChat::ForceString $= "") {
	$CustomChat::ForceString = 0;
}

if($Pref::Client::CustomChat::CustomChatString $= "") {
	// fallback
	$CustomChat::StringData = $Pref::Client::CustomChat::CustomChatString = "\c3%n%\c6: %m%";
}
if($CustomChat::StringData $= "") {
	$CustomChat::StringData = $Pref::Client::CustomChat::CustomChatString;
}

function clientCmdCCHandshake() {
	commandToServer('CCHandshake', "v" @ $CustomChat::Version);
	echo("Server has CC overrides enabled! Your chat is forced to the server's settings if present.");
}

function clientCmdCCStringOverride(%data) {
	if(trim(%data) !$= "" && strLen(trim(%data)) >= 3) {
		$CustomChat::ForceString = 1;
		$CustomChat::StringData = %data;
	} else {
		$CustomChat::ForceString = 0;
		$CustomChat::StringData = $Pref::Client::CustomChat::CustomChatString;
	}
}

function CC_getCustomChatString(%clanPrefix, %name, %clanSuffix, %msg, %slayerColor) {
	%format = $CustomChat::StringData;
	%end_result = %format;

	// name
	if(strStr(%format, "%n%") != -1) {
		%end_result = strReplace(%end_result, "%n%", %name);
	}

	// name color
	if(strStr(%format, "%nC%") != -1) {
		if(stripMLControlChars(%name) $= $pref::Player::NetName || (stripMLControlChars(%name) $= $pref::Player::LANName && isObject(MissionCleanup))) {
			%color = "<color:" @ $Pref::Client::CustomChat::SelfNameColor @ ">";
		} else {
			if(!$Pref::Client::CustomChat::EnableRandomNameColors) {
				%color = "<color:" @ $Pref::Client::CustomChat::NameColor @ ">";
			} else {
				// random name colors are actually psuedo-random (shhhh)
				%color = "<color:" @ getRandomNameColor(%name) @ ">";
			}
		}

		%end_result = strReplace(%end_result, "%nC%", %color);
	}

	// 24h hour
	if(strStr(%format, "%tH%") != -1) {
		%end_result = strReplace(%end_result, "%tH%", getSubStr(getDateTime(), 9, 2));
	}

	// 12h hour
	if(strStr(%format, "%th%") != -1) {
		%hour = getSubStr(getDateTime(), 9, 2);
		if(%hour > 12) {
			%hour -= 12;
		}

		%end_result = strReplace(%end_result, "%th%", %hour);
	}

	// meridiem
	if(strStr(%format, "%tA%") != -1) {
		%hour = getSubStr(getDateTime(), 9, 2);
		if(%hour >= 12) {
			%ampm = "PM";
		} else {
			%ampm = "AM";
		}

		%end_result = strReplace(%end_result, "%tA%", %ampm);
	}

	// minute
	if(strStr(%format, "%tM%") != -1) {
		%end_result = strReplace(%end_result, "%tM%", getSubStr(getDateTime(), 12, 2));
	}

	// second
	if(strStr(%format, "%tS%") != -1) {
		%end_result = strReplace(%end_result, "%tS%", getSubStr(getDateTime(), 15, 2));
	}

	// unix timestamp
	if(strStr(%format, "%tU%") != -1) {
		%end_result = strReplace(%end_result, "%tU%", getUTC());
	}

	// month
	if(strStr(%format, "%tm%") != -1) {
		%end_result = strReplace(%end_result, "%tm%", getSubStr(getDateTime(), 0, 2));
	}

	// day
	if(strStr(%format, "%td%") != -1) {
		%end_result = strReplace(%end_result, "%td%", getSubStr(getDateTime(), 3, 2));
	}

	// year
	if(strStr(%format, "%ty%") != -1) {
		%end_result = strReplace(%end_result, "%ty%", getSubStr(getDateTime(), 6, 2));
	}

	// timestamp color
	if(strStr(%format, "%tC%") != -1) {
		%end_result = strReplace(%end_result, "%tC%", "<color:" @ $Pref::Client::CustomChat::TimestampColor @ ">");
	}

	// clan prefix
	if(strStr(%format, "%cP%") != -1) {
		// already stripped earlier on in clientCmdChatMessage if enabled
		%end_result = strReplace(%end_result, "%cP%", %clanPrefix);
	}

	// clan suffix
	if(strStr(%format, "%cS%") != -1) {
		// already stripped earlier on in clientCmdChatMessage if enabled
		%end_result = strReplace(%end_result, "%cS%", %clanSuffix);
	}


	// clan tag colors
	if(strStr(%format, "%cC%") != -1) {
		%end_result = strReplace(%end_result, "%cC%", "<color:" @ $Pref::Client::CustomChat::ClanTagsColor @ ">");
	}

	// message
	if(strStr(%format, "%m%") != -1) {
		%end_result = strReplace(%end_result, "%m%", %msg);
	}

	// message color
	if(strStr(%format, "%mC%") != -1) {
		if(stripMLControlChars(%name) $= $pref::Player::NetName || (stripMLControlChars(%name) $= $pref::Player::LANName && isObject(MissionCleanup))) {
			%color = "<color:" @ $Pref::Client::CustomChat::SelfMsgColor @ ">";
		} else {
			%color = "<color:" @ $Pref::Client::CustomChat::MessageColor @ ">";
		}

		%end_result = strReplace(%end_result, "%mC%", %color);
	}

	// slayer color
	if(strStr(%format, "%sC%") != -1) {
		%end_result = strReplace(%end_result, "%sC%", %slayerColor);
	}

	// slayer symbol (if applicable)
	if(strStr(%format, "%sS%") != -1) {
		%end_result = strReplace(%end_result, "%sS%", (%color $= "" ? "" : "=="));
	}

	// rank string
	if(strStr(%format, "%r%") != -1) {
		%rank = "";

		switch(isUserRanked(%name)) {
			case 1: %rank = $Pref::Client::CustomChat::AdminRankString;
			case 2: %rank = $Pref::Client::CustomChat::SuperAdminRankString;
			case 3: %rank = $Pref::Client::CustomChat::HostRankString;
		}

		%end_result = strReplace(%end_result, "%r%", %rank);
	}

	// message count
	if(strStr(%format, "%i%") != -1) {
		%end_result = strReplace(%end_result, "%i%", $CustomChat::TotalMessages);
	}

	// BL_ID
	if(strStr(%format, "%id%") != -1) {
		if(isObject(MissionCleanup)) {
			%end_result = strReplace(%end_result, "%id%", "");
		} else {
			%end_result = strReplace(%end_result, "%id%", $CustomChat::PlayerNameBLID[%name]);
		}
	}

	return %end_result;
}