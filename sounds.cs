if(!$CustomChat::SoundInit) {
	new AudioProfile(CustomChatMsgNotify) {
		fileName = $Pref::Client::CustomChat::MessageSoundFilename;
		description = AudioGui;
		preload = true;
	};
	new AudioProfile(CustomChatSelfMsgNotify : CustomChatMsgNotify) { fileName = $Pref::Client::CustomChat::SelfMessageSoundFilename; };
	new AudioProfile(CustomChatNotifySound : CustomChatMsgNotify) { fileName = $Pref::Client::CustomChat::NotifySoundFilename; };
}
$CustomChat::SoundInit = 1;