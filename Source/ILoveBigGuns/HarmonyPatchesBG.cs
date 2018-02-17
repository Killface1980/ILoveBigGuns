using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using UnityEngine;
using Verse;

namespace ILoveBigGuns
{
    [StaticConstructorOnStartup]
    public static class HarmonyPatchesBG
    {
        private static bool initialized;
        public static bool disabled;

        static HarmonyPatchesBG()
        {

            HarmonyInstance harmony = HarmonyInstance.Create("rimworld.ilovebigguns.mod");
            harmony.PatchAll(Assembly.GetExecutingAssembly());

          //  HarmonyInstance.DEBUG = true;

            // if (!initialized)
            // {
            //     if (ModLister.AllInstalledMods.Any(x => x.Active && x.Name.Equals("Facial Stuff 0.18.5")))
            //     {
            //         Log.Message("I Love Big Guns: Facial Stuff version >= 0.18.5 found");
            //         disabled = true;
            //     }
            //     initialized = true;
            // }
            //  if (disabled) { return; }

            harmony.Patch(
          AccessTools.Method(typeof(PawnRenderer), nameof(PawnRenderer.DrawEquipmentAiming)),
          null,
          null,
          new HarmonyMethod(typeof(HarmonyPatchesBG),
                            nameof(HarmonyPatchesBG.DrawEquipmentAiming_Transpiler)));


        }

        public static IEnumerable<CodeInstruction> DrawEquipmentAiming_Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> instructionList = instructions.ToList();

            int index = instructionList.FindIndex(x => x.opcode == OpCodes.Ldloc_0);

            // MethodInfo method = AccessTools.Method(typeof(Vector3), nameof(Vector3.up));
            // int vecIndex = instructionList.FindIndex(x => x.opcode == OpCodes.Call && x.operand == method);

            foreach (CodeInstruction inst in instructionList)
            {
                if (inst.opcode == OpCodes.Ldloc_0)
                {
                    yield return new CodeInstruction(OpCodes.Ldloca_S, 0);
                    yield return new CodeInstruction(OpCodes.Call,
                                                                   AccessTools.Method(typeof(HarmonyPatchesBG),
                                                                                      nameof(DoBigGuns)));
                }
                yield return inst;
            }


        }

        public static void DoBigGuns(ref Mesh weaponMesh)
        {
            if (Controller.settings.ILoveBigGuns)
            {
            bool flipped = weaponMesh == MeshPool.plane10Flip;
                if (Controller.settings.SizeDoesMatter)
                {
                    if (flipped)
                    {
                        weaponMesh = MeshPoolBG.plane20Flip;
                    }
                    else
                    {
                        weaponMesh = MeshPool.plane20;
                    }
                }
                else
                {
                    if (flipped)
                    {
                        weaponMesh = MeshPoolBG.plane14Flip;
                    }
                    else
                    {
                        weaponMesh = MeshPool.plane14;
                    }
                }

            }


        }
    }
}
