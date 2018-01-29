using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MonRepertoire.Helper.Enums
{
    public enum TonaliteEnum
    {
        C = 1,
        [Description("C#/Db")]
        Db,
        D,
        [Description("D#/Eb")]
        Eb,
        E,
        F,
        [Description("F#/Gb")]
        Gb,
        G,
        [Description("G#/Ab")]
        Ab,
        A,
        [Description("A#/Bb")]
        Bb,
        B
    }
}