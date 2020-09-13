﻿namespace ImOrg
{
    class FileTypes
    {
        public enum itemType
        {
            noExtension,
            directory,
            image,
            video,
            text,
            unsupported
        }
        public static itemType getFileType(string extension)
        {
            switch (extension)
            {
                case "":
                    return itemType.noExtension;

                case ".jpg":
                case ".jpeg":
                case ".png":
                // case ".gif":
                case ".tif":
                case ".tiff":
                case ".bmp":
                    // case ".ico":
                    // ".webp", // not supported
                    // ".dds", // not supported
                    // ".tga", // not supported
                    return itemType.image;

                // case ".webm":
                // case ".mp4":
                case ".mkv":

                // UNTESTED but in the list of supported formats:
                #region FFPLAY
                case ".3dostr":
                case ".3g2":
                case ".3gp":
                case ".4xm":
                case ".a64":
                case ".aa":
                case ".aac":
                case ".ac3":
                case ".acm":
                case ".act":
                case ".adf":
                case ".adp":
                case ".ads":
                case ".adts":
                case ".adx":
                case ".aea":
                case ".afc":
                case ".aiff":
                case ".aix":
                case ".alaw":
                case ".alias_pix":
                case ".amr":
                case ".amrnb":
                case ".amrwb":
                case ".anm":
                case ".apc":
                case ".ape":
                case ".apng":
                case ".aptx":
                case ".aptx_hd":
                case ".aqtitle":
                case ".asf":
                case ".asf_o":
                case ".asf_stream":
                case ".ass":
                case ".ast":
                case ".au":
                case ".avi":
                case ".avisynth":
                case ".avm2":
                case ".avr":
                case ".avs":
                case ".avs2":
                case ".bethsoftvid":
                case ".bfi":
                case ".bfstm":
                case ".bin":
                case ".bink":
                case ".bit":
                case ".bmp_pipe":
                case ".bmv":
                case ".boa":
                case ".brender_pix":
                case ".brstm":
                case ".c93":
                case ".caf":
                case ".cavsvideo":
                case ".cdg":
                case ".cdxl":
                case ".cine":
                case ".codec2":
                case ".codec2raw":
                case ".concat":
                case ".crc":
                case ".dash":
                case ".data":
                case ".daud":
                case ".dcstr":
                case ".dds_pipe":
                case ".dfa":
                case ".dhav":
                case ".dirac":
                case ".dnxhd":
                case ".dpx_pipe":
                case ".dsf":
                case ".dshow":
                case ".dsicin":
                case ".dss":
                case ".dts":
                case ".dtshd":
                case ".dv":
                case ".dvbsub":
                case ".dvbtxt":
                case ".dvd":
                case ".dxa":
                case ".ea":
                case ".ea_cdata":
                case ".eac3":
                case ".epaf":
                case ".exr_pipe":
                case ".f32be":
                case ".f32le":
                case ".f4v":
                case ".f64be":
                case ".f64le":
                case ".ffmetadata":
                case ".fifo":
                case ".fifo_test":
                case ".film_cpk":
                case ".filmstrip":
                case ".fits":
                case ".flac":
                case ".flic":
                case ".flv":
                case ".framecrc":
                case ".framehash":
                case ".framemd5":
                case ".frm":
                case ".fsb":
                case ".g722":
                case ".g723_1":
                case ".g726":
                case ".g726le":
                case ".g729":
                case ".gdigrab":
                case ".gdv":
                case ".genh":
                case ".gif":
                case ".gif_pipe":
                case ".gsm":
                case ".gxf":
                case ".h261":
                case ".h263":
                case ".h264":
                case ".hash":
                case ".hcom":
                case ".hds":
                case ".hevc":
                case ".hls":
                case ".hnm":
                case ".ico":
                case ".idcin":
                case ".idf":
                case ".iff":
                case ".ifv":
                case ".ilbc":
                case ".image2":
                case ".image2pipe":
                case ".ingenient":
                case ".ipmovie":
                case ".ipod":
                case ".ircam":
                case ".ismv":
                case ".iss":
                case ".iv8":
                case ".ivf":
                case ".ivr":
                case ".j2k_pipe":
                case ".jacosub":
                case ".jpeg_pipe":
                case ".jpegls_pipe":
                case ".jv":
                case ".kux":
                case ".latm":
                case ".lavfi":
                case ".libopenmpt":
                case ".live_flv":
                case ".lmlm4":
                case ".loas":
                case ".lrc":
                case ".lvf":
                case ".lxf":
                case ".m4v":
                case ".matroska":
                case ".md5":
                case ".mgsts":
                case ".microdvd":
                case ".mjpeg":
                case ".mjpeg_2000":
                case ".mkvtimestamp_v2":
                case ".mlp":
                case ".mlv":
                case ".mm":
                case ".mmf":
                case ".mov":
                case ".m4a":
                case ".mj2":
                case ".mp2":
                case ".mp3":
                case ".mp4":
                case ".mpc":
                case ".mpc8":
                case ".mpeg":
                case ".mpeg1video":
                case ".mpeg2video":
                case ".mpegts":
                case ".mpegtsraw":
                case ".mpegvideo":
                case ".mpjpeg":
                case ".mpl2":
                case ".mpsub":
                case ".msf":
                case ".msnwctcp":
                case ".mtaf":
                case ".mtv":
                case ".mulaw":
                case ".musx":
                case ".mv":
                case ".mvi":
                case ".mxf":
                case ".mxf_d10":
                case ".mxf_opatom":
                case ".mxg":
                case ".nc":
                case ".nistsphere":
                case ".nsp":
                case ".nsv":
                case ".null":
                case ".nut":
                case ".nuv":
                case ".oga":
                case ".ogg":
                case ".ogv":
                case ".oma":
                case ".opus":
                case ".paf":
                case ".pam_pipe":
                case ".pbm_pipe":
                case ".pcx_pipe":
                case ".pgm_pipe":
                case ".pgmyuv_pipe":
                case ".pictor_pipe":
                case ".pjs":
                case ".pmp":
                case ".png_pipe":
                case ".ppm_pipe":
                case ".psd_pipe":
                case ".psp":
                case ".psxstr":
                case ".pva":
                case ".pvf":
                case ".qcp":
                case ".qdraw_pipe":
                case ".r3d":
                case ".rawvideo":
                case ".realtext":
                case ".redspark":
                case ".rl2":
                case ".rm":
                case ".roq":
                case ".rpl":
                case ".rsd":
                case ".rso":
                case ".rtp":
                case ".rtp_mpegts":
                case ".rtsp":
                case ".s16be":
                case ".s16le":
                case ".s24be":
                case ".s24le":
                case ".s32be":
                case ".s32le":
                case ".s337m":
                case ".s8":
                case ".sami":
                case ".sap":
                case ".sbc":
                case ".sbg":
                case ".scc":
                case ".sdl":
                case ".sdl2":
                case ".sdp":
                case ".sdr2":
                case ".sds":
                case ".sdx":
                case ".segment":
                case ".ser":
                case ".sgi_pipe":
                case ".shn":
                case ".siff":
                case ".singlejpeg":
                case ".sln":
                case ".smjpeg":
                case ".smk":
                case ".smoothstreaming":
                case ".smush":
                case ".sol":
                case ".sox":
                case ".spdif":
                case ".spx":
                case ".srt":
                case ".stl":
                case ".stream_segment":
                case ".ssegment":
                case ".subviewer":
                case ".subviewer1":
                case ".sunrast_pipe":
                case ".sup":
                case ".svag":
                case ".svcd":
                case ".svg_pipe":
                case ".swf":
                case ".tak":
                case ".tedcaptions":
                case ".tee":
                case ".thp":
                case ".tiertexseq":
                case ".tiff_pipe":
                case ".tmv":
                case ".truehd":
                case ".tta":
                case ".tty":
                case ".txd":
                case ".ty":
                case ".u16be":
                case ".u16le":
                case ".u24be":
                case ".u24le":
                case ".u32be":
                case ".u32le":
                case ".u8":
                case ".uncodedframecrc":
                case ".v210":
                case ".v210x":
                case ".vag":
                case ".vc1":
                case ".vc1test":
                case ".vcd":
                case ".vfwcap":
                case ".vidc":
                case ".vividas":
                case ".vivo":
                case ".vmd":
                case ".vob":
                case ".vobsub":
                case ".voc":
                case ".vpk":
                case ".vplayer":
                case ".vqf":
                case ".w64":
                case ".wav":
                case ".wc3movie":
                case ".webm":
                case ".webm_chunk":
                case ".webm_dash_manifest":
                case ".webp":
                case ".webp_pipe":
                case ".webvtt":
                case ".wsaud":
                case ".wsd":
                case ".wsvqa":
                case ".wtv":
                case ".wv":
                case ".wve":
                case ".xa":
                case ".xbin":
                case ".xmv":
                case ".xpm_pipe":
                case ".xvag":
                case ".xwd_pipe":
                case ".xwma":
                case ".yop":
                case ".yuv4mpegpipe":
                    return itemType.video;
                #endregion

                #region TXT
                case ".txt":
                case ".csv":
                case ".log":
                case ".xml":
                case ".json":
                case ".xaml":
                    return itemType.text;
                #endregion

                case "Directory":
                    return itemType.directory;

                default:
                    return itemType.unsupported;
            }
        }

    }
}