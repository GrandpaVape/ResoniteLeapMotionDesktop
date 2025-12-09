using FrooxEngine;
using HarmonyLib;
using ResoniteModLoader;

namespace LeapMotionMod;
//More info on creating mods can be found https://github.com/resonite-modding-group/ResoniteModLoader/wiki/Creating-Mods
public class LeapMotionMod : ResoniteMod {
	internal const string VERSION_CONSTANT = "1.0.0"; //Changing the version here updates it in all locations needed
	public override string Name => "LeapMotionMod";
	public override string Author => "GrandpaVape";
	public override string Version => VERSION_CONSTANT;
	public override string Link => "https://github.com/resonite-modding-group/ExampleMod/";

	public override void OnEngineInit() {
		Harmony harmony = new Harmony("GrandpaVape.LeapDesktopMod");
		harmony.PatchAll();
	}

	[HarmonyPatch( typeof(LeapMotionDriver), "UpdateInputs" )]
	class LeapMotionDriver_UpdateInputs_Patch
	{
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
		{
			var codes = new List<CodeInstruction>(instructions);
			codes.RemoveRange(26, 19);
			return codes.AsEnumerable();
		}
	}
}
