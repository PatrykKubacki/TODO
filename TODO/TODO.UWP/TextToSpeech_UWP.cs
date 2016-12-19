using System;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml.Controls;
using TODO.Interfaces;
using TODO.UWP;
using Xamarin.Forms;

[assembly:Dependency(typeof(TextToSpeech_UWP))]

namespace TODO.UWP {

	public class TextToSpeech_UWP : ITextToSpeech{

		public async void Speak(string text) {
			SpeechSynthesizer synthesizer = new SpeechSynthesizer();

			try {
				var stream = await synthesizer.SynthesizeTextToStreamAsync(text);
				var mediaElement = new MediaElement();
				mediaElement.SetSource(stream,stream.ContentType);
				mediaElement.Play();
			}
			catch (Exception exception) {
				throw exception;
			}
		}
	}
}
