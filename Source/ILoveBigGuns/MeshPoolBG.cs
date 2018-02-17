// ReSharper disable StyleCop.SA1401

using Harmony;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using FacialStuff;

namespace ILoveBigGuns
{
    [StaticConstructorOnStartup]
    public static class MeshPoolBG
    {

        #region Public Fields

        public static readonly Mesh plane14Flip;
        public static readonly Mesh plane20Flip;

        #endregion Public Fields


        #region Public Constructors

        static MeshPoolBG()
        {
            plane14Flip = MeshMakerPlanesFS.NewPlaneMesh(1.4f, true);
            plane20Flip = MeshMakerPlanesFS.NewPlaneMesh(2f, true);

        }

        #endregion Public Constructors

    }
}