using GadgetCore.API;
using Roguelands.MoreCombatChips.DataStructures;

namespace Roguelands.MoreCombatChips.CombatChips
{
  public class TechXXChip : BaseChip
  {
    public override ChipType Type => ChipType.PASSIVE;

    public override string Name => "Tech XX";

    public override string Description => "+24 Tech";

    public override EquipStats Stats => new EquipStats(0, 0, 0, 24, 0, 0);

    protected override void StoreExtraDetails(ref ModdedChip moddedChip)
    {
      base.StoreExtraDetails(ref moddedChip);
      ApplyMoreAdvancedChipData(ref moddedChip);
    }
  }
}