# The Goals of this Mod

Rebalance the game, duh!

---

# Analysis of Problematic Buildings

## Automatic Dispenser

The primary use case of this building is to remain unpowered and dispense immediately.
Almost nobody ever powers these, so I see a couple of sensible ways to rework this building:
- holding items is now free, with *dispensing* items requiring power instead
- get rid of the power input entirely

## Smart Storage Bin

Problems:
- Weight plates are almost always a better option since they do not require power.
    - remove power requirement.
- Requiring refined metal is excessive for what these do
    - allow them to be built with metal ores

## Algae Terrarium

This is an interesting building that is held back primarily by its labor requirements and the fact that it never overpressurizes.

Solution: keep net water consumption rate, but massively reduce water pollution rate
    * -300 g/s -> -50 g/s water
    * +290 g/s -> +40 g/s pwater
This change requires emptying every 9 cycles instead of needing a change every \~1.25 cycles, a 7.2x improvement

The lighting efficiency bonus might be raised to 15%, but 10% is pretty ok

I'm considering making this *produce* algae under light and presence of CO2, but I suspect that is overpowered.

## Electrolyzer

Electrolyzers are the main event when it comes to oxygen production.

There's no better option than electrolyzers for the long term sustainability (and scalability) of a colony.
Since this is mostly due to only requiring water (which can be produced sustainably in a number of ways),
This is acceptable as a whole.

All that said, they need a slight nerf in order to create more interesting engineering challenges.

Problems:
- SPOMs are so optimal that there is little reason to do more interesting electrolyzer builds.
    - There aren't enough serious tradeoffs.
- The gases come out too hot to consider most other electrolyzer builds seriously.
    You have to have a serious cooling solution in place which you almost certainly want to pump
    through a block of metal tiles or something like that.
- Electrolyzer rooms overpressure too easily. It's very difficult to run a 100% uptime electrolyzer build, even in space.
- The Gas Pump buff needs to be counteracted or else SPOMs become far too strong

To compensate for the gas pump changes, this would need to cost 360W/kg or more to run.

The Fix:
*  -120W         -> -300W
* -1000g/s       -> -750g/s water
*  +888g/s @70+C -> +666g/s @50+C oxygen
*  +112g/s @70+C ->  +84g/s @50+C hydrogen
*  +1.25 kDTU/s  ->  +2.5 kDTU/s

## Rust Deoxidizer

This building is *probably* fine as is.

## Wood Burner

Wood Burners are insanely inefficient. They produce too much CO2 and cost too much lumber.

Fix:
* -1200g/s -> -600g/s wood
*  +170g/s ->  +30g/s CO2
*  +9kDTU  ->  +4.5kDTU

With that change, they generate the same heat per watt as Coal Generators and are only slightly less resource efficient.

## Large Power Transformer

Generating 4kW is a little silly since conductive wire can only handle 2kW. But this is not unbalanced.

Still, there's a couple mods that deal with this ideosyncracy already and I'd rather that be an opt-in feature via those mods.

## Airborne Critter Bait

In most cases, you can easily trick ranchers into wrangling airborne critters via a Critter Drop-Off

Costing metal ore is excessive for what little value it provides.

Make it cost raw minerals instead.

## Critter Trap / Fish Trap

Consuming plastic is absolutely insane since you'll have a rancher long before you'll ever have plastic.

Make it cost raw minerals instead.

## Liquid Filter / Gas Filter / Solid Filter

These can be simulated less expensively with a shutoff valve and an element sensor, provided
that the substance flows at full speed

Solution: reduce power to 20W. Bringing them down to 10W sounds reasonable at face value,
but the convenience factor and better handling of edge cases is worth some power, just not 110W.

## Gas Pump

Gas pumps cost the same amount of power as liquid pumps but only fill gas vents halfway.
While you *could* increase the pumping speed to 1000g/s, this sucks out gas far faster than it can
diffuse in a typical 1.8-2kg/tile pressure, and would result in pumps being unable to run at full
speed in most cases.

The solution then is to reduce its power requirement to 120W.

## Mini Gas Pump

In accordance with the power cost reduction of the full size gas pump, reduce power requirement to 30W.

## Algae Distiller

Held back by excessive heat generation (and heat multiplication) and slow output

The fix:
* -600g/s -> -3000g/s slime
* +200g/s -> +1000g/s algae
* +400g/s -> +2000g/s pwater
* +1.5kDTU/s -> +1kDTU/s

## Compost

Produces too much heat and requires too much labor

## Desalinator

Too much heat generation, power cost too high

It's a necessary evil when you have salt water and few other power sources

desalination via steam turbine is often a better option.

## Ethanol Distiller

These simply aren't worth the effort for the ethanol. You probably "want" the polluted dirt or CO2.

They also generate far too much heat.

For power, they produce enough ethanol for a net 260J/kg, but wood burners produce 250J/kg.
Considering how inefficient wood burners are to begin with, this is a *terrible* deal.

The fix:
* -240W               -> -120W
* +500g/s     @73.4+C -> +700g/s @50+C ethanol
* +333.333g/s @93.4+C -> +200g/s @50+C polluted dirt
* +166.667g/s @93.4+C -> +100g/s @70+C CO2
* +4.5kDTU/s          -> +2kDTU/s

This increases the net power production from 260J/kg to 580J/kg, now 80J/kg more efficient than the
buffed wood burners and 30J/kg more energy-dense than coal.

## Fertilizer Synthesizer

Output more natural gas?
Process more matter per second?

## Glass Forge

Maybe should require less power?

## Oil Refinery

Should perhaps produce more natural gas?

## Sludge Press

Requires too much labor.

Fix: Crafting time reduced to 10s

Potentially impossible Fix: remove labor requirement with stats:
* -3000g/s mud/pmud
* +1200g/s dirt/pdirt
* +1800g/s water/pwater

## Medical Buildings

Germs and disease are kind of irrelevant. Perhaps slimelung should last longer without treatment?

Maybe it's okay that disease is mostly irrelevant since the real engineering challenges are elsewhere.

There are mods and difficulty settings to address this, so I will leave these buildings untouched.

## Recreational Buildings

Morale bonuses and buffs will be reworked to better match their power/ingredient requirements.

## Power Control Station

Costs too much metal per microchip to be worth the bother. Except with lead.

Require 10kg sand + 500g refined metal, but disallow lead

Power rooms max size increased to 120 to make this building easier to take advantage of.

## Farm Station

The fertilizer buff isn't worth it due to both labor requirements and resource usage.

Solution: Increase Farmer's Touch buff duration to 3 cycles and reduce buff applying time to 5s.

## Ice-E Fan

I don't know what to do with this building. All I know is that it's bad.

## Ore Scrubber

The main problem with this building is that it only applies to things that duplicants interact with manually

Turns out it applies to liquid bottles too, but this is impractical.

The fix: add a liquid input and output so you can use it instead of chlorine decontamination rooms from your bathroom.

Except that really doesn't matter.

## Space Heater

This building doesn't transfer its heat to air fast enough and produces too little heat per Watt,
so it is generally only good as a temporary quick and dirty heating solution...
except that a kiln is more practical most of the time.

- Add a tempshift-plate-like effect to the 4 tiles it occupies, much like the Ice-E Fan.
- Increase heat output to 180 kDTU/s
- Increase overheat temperature to 175C

## Thermo Regulator

This building is half as power efficient as aquatuners per C, which is too large of a tradeoff for its ease of use.

Also, considering that Hydrogen is the most practical gas coolant (with a SHC of 2.4 vs water/steam's 4.179 or super coolant's 8.44)
it just can't compete with the aquatuner in any sensible situation.

It would also be nice if it were practical to cool oxygen directly

With all that in mind, there are a few options for rebalancing this building:

* Reduce power consumption to 120W or less
* Massively increase cooling factor to 30-40C
    - this introduces some really interesting interactions where you can outperform aquatuners per watt for cooling very hot things with steam or supercoolant.

Alternative: change cooling factor to a fixed kDTU/kg instead of a fixed temperature difference (for both this building and the aquatuner)
- This is a massive nerf to supercoolant, however...


## Automation

No complaints here. Works as expected.

## Rocketry

No issues here

## Radiation Lamp

There's basically no reason to use this building, ever.

5 Wheezeworts in a V-shape produce WAY more radiation without electricity,
provided you have a safe way to feed them phosphorite or can plant them with pips.

This probably means nerfing the radiation output of Wheezeworts

---

# Morale Issues

There are a lot of no-brainer sources of easy morale that make it far too easy to skill up your dupes

## Great Hall

The Great Hall bonus is far too easy to obtain for its incredible +6 morale bonus.
The simplest way to get it is to add a disabled water cooler and a decorative plant to a mess hall.

The fix:
- Change decor 20 requirement to one of:
    - 2 completed pieces of art (any quality)
    - Decor 50 item
    - Any artifact displayed on a pedestal (relatively easy in spaced out, very late game in base game)
- Recreational building must be active for the requirement to be met
- Now requires powered fridge (if possible as a constraint. Any fridge is fine otherwise.)
- All mess tables must be lit (if this is possible to add as a constraint)

In addition, the morale bonus should be nerfed to +3 or +4, with the Mess hall bonus also being nerfed accordingly

## Parks and Nature Reserves

The conditions are fine, but the bonus is too big considering some of the clever ways you can get
these bonuses and trick dupes into walking through them.
(e.g. put one in the kitchen, put one next to bedrooms/bathrooms, put one in the main shaft, etc...)

Morale buff reduced to +1 and +3, respectively

## Barbecue

Barbecue provides +8 morale as a byproduct of ranching (which has other substantial benefits that justify ranching on their own.)

Baby critters provide the same amount of meat as adults, making drowning chambers the most straightforward way to produce meat.

The fix:
- Barbecue food quality reduced from 3 to 2 (same as omelette, but more calorie efficient)
- Baby critters (first 5 cycles of life) produce 1/4 the amount of meat as adults.
- The food morale tweaks below

## Food Quality vs Morale Bonus

Food morale is out of control. The morale curve is just crazy and needs to be toned down:

* -1 -> -1
* 0 -> 0
* 1 -> 1
* 2 -> 2 (from 4)
* 3 -> 4 (from 8)
* 4 -> 7 (from 12)
* 5+ -> 10 (from 16)

---

# Ranching

## Pufts and Slicksters

They don't eat gases fast enough, so scaling them up ends up being utterly impractical.


## Starvation Ranching

I am uncertain whether I want to make starvation ranching unviable as a food source, particularly for shove voles.


---

# Creative Builds

## Petroleum Boilers

These are really strong and are water positive, but I'm not sure if they're overpowered given how finnicky they are.

It could be interesting if boiling crude oil to petroleum left behind something (probably bitumen) instead of having a 100% conversion rate.

Alternatively, the Asphalt Tile mod would be a good recommended mod to create a tradeoff out of this
