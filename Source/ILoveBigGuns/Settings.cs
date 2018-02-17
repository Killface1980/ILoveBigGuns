// ReSharper disable StyleCop.SA1401

using RimWorld;
using UnityEngine;
using Verse;

namespace ILoveBigGuns
{
    public class Settings : ModSettings
    {
        #region Private Fields

        private bool iLoveBigGuns = false;
        #endregion Private Fields

        #region Public Properties


        public bool ILoveBigGuns => this.iLoveBigGuns;
        bool sizeDoesMatter;
        public bool SizeDoesMatter
        {
            get => this.sizeDoesMatter;
        }
        #endregion Public Properties

        #region Public Methods

        public void DoWindowContents(Rect inRect)
        {
            Rect rect = inRect.ContractedBy(15f);
            Listing_Standard list = new Listing_Standard(GameFont.Small) { ColumnWidth = (rect.width / 2) - 17f };

            list.Begin(rect);

          //  if (HarmonyPatchesBG.disabled)
          //  {
          //      list.Label("I Love Big Guns was disabled by Facial Stuff mod. Please use the FS settings for bigger better guns. \nSincerely, Killface");
          //  list.Gap();
          //  }

            list.Label("Settings.BigGunLabel".Translate());
            list.GapLine();



            list.Gap();

            list.CheckboxLabeled("Settings.ILoveBigGuns".Translate(),
                ref this.iLoveBigGuns,
                "Settings.ILoveBigGunsTooltip".Translate());

            list.CheckboxLabeled("Settings.SizeDoesMatter".Translate(),
                ref this.sizeDoesMatter,
                "Settings.SizeDoesMatterTooltip".Translate());



            //   list.CheckboxLabeled("Settings.ILikeBigHeads".Translate(), ref this.iLikeBigHeads, "Settings.ILikeBigHeadsTooltip".Translate());

            // if (list.ButtonText("Reset"))
            // {
            // Controller.settings = new Settings();
            // }


            // list.CheckboxLabeled(
            // "Settings.UseFreeWill".Translate(),
            // ref this.useFreeWill,
            // "Settings.UseFreeWillTooltip".Translate());

            // this.useDNAByFaction = Toggle(this.useDNAByFaction, "Settings.UseDNAByFaction".Translate());
            list.End();

            if (GUI.changed)
            {
                this.Mod.WriteSettings();
            }

            // FlexibleSpace();
            // BeginVertical();
            // if (Button("Settings.Apply".Translate()))
            // {
            // foreach (Pawn pawn in PawnsFinder.AllMapsAndWorld_Alive)
            // {
            // if (pawn.RaceProps.Humanlike)
            // {
            // CompFace faceComp = pawn.TryGetComp<CompFace>();
            // if (faceComp != null)
            // {
            // this.WriteSettings();
            // faceComp.sessionOptimized = false;
            // pawn.PawnDrawer.renderer.graphics.ResolveAllGraphics();
            // }
            // }
            // }
            // }
            // EndVertical();
            // FlexibleSpace();
        }

        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Values.Look(ref this.iLoveBigGuns, "iLoveBigGuns", false, true);
            Scribe_Values.Look(ref this.sizeDoesMatter, "sizeDoesMatter", false, true);
        }

        #endregion Public Methods
    }
}