using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using RimWorld;
using UnityEngine;
using Verse;

namespace ILoveBigGuns
{
    public class Controller : Mod
    {

        // ReSharper disable once InconsistentNaming
        // ReSharper disable once StyleCop.SA1307
        [NotNull]
        [SuppressMessage(
            "StyleCop.CSharp.MaintainabilityRules",
            "SA1401:FieldsMustBePrivate",
            Justification = "Reviewed. Suppression is OK here.")]
        public static Settings settings;

        public Controller(ModContentPack content)
            : base(content)
        {
            settings = this.GetSettings<Settings>();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            settings.DoWindowContents(inRect);
        }

        public override string SettingsCategory()
        {
            return "I Love Big Guns";
        }

        // ReSharper disable once MissingXmlDoc
        public override void WriteSettings()
        {
            settings?.Write();

        }
    }
}