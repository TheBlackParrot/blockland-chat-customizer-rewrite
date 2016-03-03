// http://pecon.us/wiki/BlockDoc/index.php?title=RGBToHex as of Jan. 24th, 2016
function CC_RGBToHex(%rgb) {
	%rgb = getWords(%rgb,0,2);
	for(%i=0;%i<getWordCount(%rgb);%i++) {
		%dec = mFloor(getWord(%rgb,%i));
		%str = "0123456789ABCDEF";
		%hex = "";

		while(%dec != 0) {
			%hexn = %dec % 16;
			%dec = mFloor(%dec / 16);
			%hex = getSubStr(%str,%hexn,1) @ %hex;    
		}

		if(strLen(%hex) == 1)
			%hex = "0" @ %hex;
		if(!strLen(%hex))
			%hex = "00";

		%hexstr = %hexstr @ %hex;
	}

	if(%hexstr $= "") {
		%hexstr = "FF00FF";
	}
	return %hexstr;
}

function HexToRGB(%hex) {
	if(strLen(%hex) < 6) {
		return;
	}
	
	%chars = "0123456789abcdef";

	for(%i=0;%i<3;%i++) {
		%value = getSubStr(%hex, 2*%i, 2);

		%first = getSubStr(%value, 0, 1);
		%last = getSubStr(%value, 1, 1);
		
		%first = stripos(%chars, %first)*16;
		%last = stripos(%chars, %last);

		%sum = %first + %last;
		%str = trim(%str SPC %sum);
	}

	return %str;
}

function escapeColorChars(%string) {
	%string = strReplace(%string, "\c0", "\\c0");
	%string = strReplace(%string, "\c1", "\\c1");
	%string = strReplace(%string, "\c2", "\\c2");
	%string = strReplace(%string, "\c3", "\\c3");
	%string = strReplace(%string, "\c4", "\\c4");
	%string = strReplace(%string, "\c5", "\\c5");
	%string = strReplace(%string, "\c6", "\\c6");
	%string = strReplace(%string, "\c7", "\\c7");
	%string = strReplace(%string, "\c8", "\\c8");
	%string = strReplace(%string, "\c9", "\\c9");
	
	return %string;
}