function initCCCSwatches() {
	%pattern = "Add-Ons/Client_CustomChat/gui/swatches/*.gui";

	for(%filename = findFirstFile(%pattern); %filename !$= ""; %filename = findNextFile(%pattern)) {
		echo("ADDING CCC SWATCH" SPC %filename);
		exec(%filename);

		%swatch = fileBase(%filename);
		
		if(!isObject(%swatch)) {
			echo("INVALID SWATCH FILENAME:" SPC %filename);
			continue;
		}

		%main = %swatch;
		if(stripos(%main, "_", 4) != -1) {
			%main = getSubStr(%main, 0, stripos(%main, "_", 4));
		}
		%main = %main @ "Main";

		if(!isObject(%main)) {
			echo("MAIN SWATCH DOESN'T EXIST:" SPC %main);
			continue;
		}

		%yoff = getWord(%main.getExtent(), 1);
		%newpos = getWords(vectorAdd(%swatch.position, "0" SPC %yoff), 0, 1);
		%swatch.resize(0, getWord(%newpos, 1), 494, getWord(%swatch.getExtent(), 1));

		%main.add(%swatch);
		%main.resize(getWord(%main.position, 0), getWord(%main.position, 1), 494, getWord(%main.getExtent(), 1)+getWord(%swatch.getExtent(), 1));

		if(isObject("CCCtempswatch")) {
			CCCtempswatch.delete();
		}
	}
}
initCCCSwatches();