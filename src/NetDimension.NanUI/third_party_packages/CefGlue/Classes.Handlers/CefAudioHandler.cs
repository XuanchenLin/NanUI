//
// Feature removed since CEF 77.
//
/*
namespace Xilium.CefGlue
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using Xilium.CefGlue.Interop;

    /// <summary>
    /// Implement this interface to handle audio events
    /// All methods will be called on the UI thread
    /// </summary>
    public abstract unsafe partial class CefAudioHandler
    {
        private void on_audio_stream_started(cef_audio_handler_t* self, cef_browser_t* browser, int audio_stream_id, int channels, CefChannelLayout channel_layout, int sample_rate, int frames_per_buffer)
        {
            CheckSelf(self);

            var mBrowser = CefBrowser.FromNative(browser);
            OnAudioStreamStarted(mBrowser, audio_stream_id, channels, channel_layout, sample_rate, frames_per_buffer);
        }

        /// <summary>
        /// Called when the stream identified by |audio_stream_id| has started.
        /// |audio_stream_id| will uniquely identify the stream across all future
        /// CefAudioHandler callbacks. OnAudioSteamStopped will always be called after
        /// OnAudioStreamStarted; both methods may be called multiple times for the
        /// same stream. |channels| is the number of channels, |channel_layout| is the
        /// layout of the channels and |sample_rate| is the stream sample rate.
        /// |frames_per_buffer| is the maximum number of frames that will occur in the
        /// PCM packet passed to OnAudioStreamPacket.
        /// </summary>
        protected abstract void OnAudioStreamStarted(CefBrowser browser, int audioStreamId, int channels, CefChannelLayout channelLayout, int sampleRate, int framesPerBuffer);


        private void on_audio_stream_packet(cef_audio_handler_t* self, cef_browser_t* browser, int audio_stream_id, float** data, int frames, long pts)
        {
            CheckSelf(self);

            var mBrowser = CefBrowser.FromNative(browser);
            OnAudioStreamPacket(mBrowser, audio_stream_id, (IntPtr)data, frames, pts);
        }

        /// <summary>
        /// Called when a PCM packet is received for the stream identified by
        /// |audio_stream_id|. |data| is an array representing the raw PCM data as a
        /// floating point type, i.e. 4-byte value(s). |frames| is the number of frames
        /// in the PCM packet. |pts| is the presentation timestamp (in milliseconds
        /// since the Unix Epoch) and represents the time at which the decompressed
        /// packet should be presented to the user. Based on |frames| and the
        /// |channel_layout| value passed to OnAudioStreamStarted you can calculate the
        /// size of the |data| array in bytes.
        /// 
        /// |data| type is |float**|
        /// </summary>
        protected abstract void OnAudioStreamPacket(CefBrowser browser, int audioStreamId, IntPtr data, int frames, long pts);


        private void on_audio_stream_stopped(cef_audio_handler_t* self, cef_browser_t* browser, int audio_stream_id)
        {
            CheckSelf(self);

            var mBrowser = CefBrowser.FromNative(browser);
            OnAudioStreamStopped(mBrowser, audio_stream_id);
        }

        /// <summary>
        /// Called when the stream identified by |audio_stream_id| has stopped.
        /// OnAudioSteamStopped will always be called after OnAudioStreamStarted; both
        /// methods may be called multiple times for the same stream.
        /// </summary>
        protected abstract void OnAudioStreamStopped(CefBrowser browser, int audioStreamId);
    }
}
*/
