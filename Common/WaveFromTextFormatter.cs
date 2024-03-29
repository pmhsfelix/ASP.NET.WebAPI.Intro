﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class WaveFromTextFormatter : MediaTypeFormatter
    {

        public WaveFromTextFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("audio/x-wav"));
            this.AddUriPathExtensionMapping("wav", "audio/x-wav");
            this.AddQueryStringMapping("accept", "wav", "audio/x-wav");
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof(string);
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream stream, HttpContentHeaders contentHeaders, TransportContext transportContext)
        {
            return SyncTask.From(() =>
            {
                var s = value as string;
                if (s == null) return;
                using (var synth = new SpeechSynthesizer())
                {
                    var ms = new MemoryStream();
                    synth.SetOutputToWaveStream(ms);
                    //synth.Rate -= 10;
                    synth.Speak("response is " + s);
                    ms.Seek(0, SeekOrigin.Begin);
                    ms.CopyTo(stream);
                }
                stream.Flush();
                //stream.Close();
            });
        }
    }
}

