# The Goals of this Mod

Rebalance the game, duh!

---

- ❔ in a heading indicates that some rebalance is needed, but it's unclear what that should be.
- ✔️ in a heading indicates the rebalance has been implemented.
- 🌙 indicates that some of the rebalance has been implemented, but some elements that I want to add are not yet implemented.
- ❌ indicates that, after careful consideration, the building was deemed to be balanced or that "balancing" functionality should be left to other mods.

# Analysis of Problematic Buildings

## Automatic Dispenser ✔️

The primary use case of this building is to remain dispense contents immediately.
The problem is that this behavior is the one that is free, so the building remains unpowered in almost every use case.

Changes:
* Dispensing items now requires power
* Now only consumes power when dispensing
* Power consumption increased to 120W (from 60W)

## Smart Storage Bin ✔️

Weight plates are almost always a better option since they do not require power.
Requiring refined metal is excessive for what these do

Changes:
* no longer requires power
* now built with metal ore

## Algae Terrarium ✔️

This is an interesting building that is held back primarily by its labor requirements and the fact that it never overpressurizes.

Solution: keep net water consumption rate, but massively reduce water pollution rate
* -300 g/s -> -50 g/s water
* +290 g/s -> +40 g/s pwater
This change requires emptying every 9 cycles instead of needing a change every \~1.25 cycles, a 7.2x improvement in labor cost

The lighting efficiency bonus might be raised to 15%, but 10% is pretty ok

I'm considering making this *produce* algae under light and presence of CO2, but I suspect that is overpowered.

## Electrolyzer ✔️

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
    - That is unless you do a hydra, which I don't particularly like because it's cheesy.

Changes:
*  -120W         -> -150W
* -1000g/s       -> -750g/s water
*  +888g/s @70+C -> +666g/s @50+C oxygen
*  +112g/s @70+C ->  +84g/s @50+C hydrogen
*  +1.25 kDTU/s  ->  +4 kDTU/s

The funny thing is that this is STILL energy-positive despite reducing the conversion rate by 25%
because it is equivalent to raising the power cost to 200W, and a 2-electrolyzer, 3-pump build has
just over 360W of excess power. (that same build still has 200W excess after this change)

Additional functionality worth considering:
- electrolyzing saltwater outputs chlorine, hydrogen, and sand
- electrolyzing brine outputs more chlorine and sand, less hydrogen

## Rust Deoxidizer ❔

This building needs further analysis, but I suspect it is fine as-is.

## Wood Burner ✔️

Wood Burners are inefficient and they produce a lot of CO2. The simple CO2 production is quite helpful.

Changes:
* -1200g/s -> -750g/s wood
*  +170g/s -> +100g/s CO2 @
*  +9kDTU  ->   +5kDTU

Still not as good as coal, but it's still kinda viable.

## Petroleum Generator ✔️

The ethanol distiller change makes domestic arbor trees water-positive. No bueno.

Changes:
* +750g/s -> +600g/s pwater

This incidentally also makes petroleum boilers no longer water positive (they now have 10% loss)

## Large Power Transformer ❌

Generating 4kW is a little silly since conductive wire can only handle 2kW. But this is not unbalanced.

Still, there's a couple mods that deal with this ideosyncracy already and I'd rather that be an opt-in feature via those mods.

## Conductive Wire ✔️

Dupes like it better *and* it handles twice as much wattage. Except I rarely find myself upgrading the wires because
it doesn't feel like enough of an improvement to bother with refining the metal for it.

However, 2kW is sorta hard to work with at times. You generally can't combine two high-wattage buildings
on the same circuit when using conductive wire, for instance one building requiring 1200W can't *quite*
share a circuit with one requiring 960W.

Also consider that the heavy watt variant handles 2.5x as much wattage as its counterpart.

The question is whether this is actually unbalanced or just mildly annoying.

The only logical argument I can think of for why conductive should be buffed is that the refined
metal is better spent on the power spine. I'm not sure that's convincing.

Change:
* Increase wattage rating to 2.5kW

What's fun about this change is that it adds a tradeoff to conductive wire where you can choose to:
- under-provision the wire to 2kW using 2 small transformers, but you don't get the full wattage it's capable of carrying
- over-provision the wire to 4kW using a large transformer, but risking overloads unless you keep the potential load at or below 2.5kW

## Airborne Critter Bait ✔️

In most cases, you can easily trick ranchers into wrangling airborne critters via a Critter Drop-Off

Costing metal ore is excessive for what little value it provides.

This building now requires raw minerals instead.

## Critter Trap / Fish Trap ✔️

Consuming plastic is absolutely insane since you'll have a rancher long before you'll ever have plastic.

Both buildings now require raw minerals instead.

## Incubator ✔️

Incubators are generally not worth powering unless you cheese the Lullabied buff with a timer sensor,
making the tradeoff of powering the building less interesting.

Changes:
* Reduce power consumption to 60W
* The Lullabied buff is lost when the building is unpowered or disabled or the egg is removed from the incubator.
    - as an interesting side effect, this can be used to grind up a rancher's Husbandry (neat!)

## Grooming Station

I just want to fix the Husbandry skill bug (if possible) because Klei can't be bothered to fix it themselves.

## Microbe Musher ✔️

Uses way more power than the grill for some reason. Even though it's a zero-tech building.

Changes:
* Power Consumption reduced to 60W

## Electric Grill ✔️

Surprisingly light on power usage. Let's bump that up just a bit.

Changes:
* Power Consumption increased to 120W

## Liquid Filter / Gas Filter / Solid Filter ✔️

These can be simulated less expensively with a shutoff valve and an element sensor, provided
that the substance flows at full speed

Solution: reduce power to 20W. Bringing them down to 10W sounds reasonable at face value,
but the convenience factor and better handling of edge cases is worth some power, just not 110W.

## Gas Pump ❌

Gas pumps cost the same amount of power as liquid pumps but only fill gas vents halfway.

My first instinct was to buff this by halving its power consumption and I even tried it in early builds of this mod,
but the more I thought about it, the more I realized it was actually very unbalanced to do so.

Gas pumping sees SO MUCH use as it is, so it doesn't really make sense to buff the building by making it cheaper to run.
Mind the fact that pumping CO2 into space has the same cost per kg as carbon skimmers yet is still the preferred option for many players.
(5 skimmers + 1 sieve = 720W, removing 1.5kg/s CO2 - same as 3 gas pumps) Cutting the cost of gas pumps would be an indirect nerf to carbon skimmers.

## Algae Distiller ✔️

Held back by excessive heat generation (mostly due to the SHC of output being higher than that of the input) and slow output

The fix:
* -120W   -> -240W
* -600g/s -> -3000g/s slime
* +200g/s -> +1000g/s algae
* +400g/s -> +2000g/s pwater
* +1.5kDTU/s -> +1kDTU/s

## Compost ❔

Produces too much heat and requires too much labor

## Desalinator ✔️

Too much heat generation, power cost too high, emptying the salt takes too long.

It's a necessary evil when you have salt water and few other power sources but just ends up being a huge hassle in practice.

It's interesting to note that IRL submarines filter saltwater for their electrolyzers using something
more akin to the water sieve, so it's crazy that this machine costs so much more power than the sieve.

Changes:
* Power cost reduced from 480W to 240W
* Heat output reduced from 8kDTU/s to 4kDTU/s
* Empty chore time reduced from 90s to 30s

## Ethanol Distiller ✔️

These simply aren't worth the effort for the ethanol. You probably "want" the polluted dirt or CO2.

They also generate far too much heat.

For power, they produce enough ethanol for a net 260J/kg, but wood burners produce 250J/kg.
Considering how inefficient wood burners are to begin with, this is a *terrible* deal.

The fix:
* -240W               -> -60W
* +500g/s     @73.4+C -> +600g/s @50+C ethanol
* +333.333g/s @93.4+C -> +300g/s @50+C polluted dirt
* +166.667g/s @93.4+C -> +100g/s @70+C CO2
* +4.5kDTU/s          -> +2kDTU/s

This increases the net power production from 260J/kg to 540J/kg, now 140J/kg more efficient than the
buffed wood burners and only 10J/kg less efficient than coal.

## Fertilizer Synthesizer ❔

Output more natural gas?
Process more matter per second?

## Glass Forge ❔

Maybe should require less power?

## Oil Refinery

The oil refinery has trouble being competitive with petroleum boilers for those who know the ways.

The labor requirements and poor product efficiency make it unappealing to use in late game builds.

Proposed:
* 5 kg/s -> 6 kg/s petroleum (this would compensate for the generator nerf in terms of water, but not in terms of power)
* 90 g/s -> 180 g/s natural gas

The question then is if this is really necessary.

## Sludge Press

Requires too much labor.

Proposed:
* Crafting time reduced to 10s

Potentially impossible Fix: remove labor requirement with stats:
* -3000g/s mud/pmud
* +1200g/s dirt/pdirt
* +1800g/s water/pwater

## Medical Buildings ❌

Germs and disease are kind of irrelevant. This is ok because the real engineering challenges are elsewhere.

There are mods and difficulty settings to address disease, so I will leave these buildings untouched.

## Art Pieces ✔️

Morale bonus is too low. Plants are better. Little reason to skill up artists.

Increase decor bonuses from 5/10/15 to 15/30/45

## Decorative Plants ✔️

Bonus is too high, making it far too easy to get the great hall bonus.

Lower decor for all decorative plants except tranquil toe and sporechid to +15

Tranquil Toes can stay at +25 because they require such a low temperature (which duplicants don't like very much)

Sporechids are interesting because they are high-risk-high-reward plants.

## Recreational Buildings ❔

Morale bonuses and buffs will be reworked to better match their power/ingredient requirements.

Needs further in-depth analysis

## Power Control Station

Costs too much metal per microchip to be worth the bother. Except with lead.

Proposed:
- Increase production yield to 3 units
- Lead recipe removed
- Power rooms max size increased to 120 to make this building easier to take advantage of.

## Farm Station

The fertilizer buff isn't worth it in most cases due to both labor requirements and resource usage.

I've seen Francis John use it for mutating plants, but that's about it.

Proposed:
- Increase Farmer's Touch buff duration to 3 cycles

## Ice-E Fan ❔

I don't know what to do with this building. All I know is that it's bad.

## Ore Scrubber ❔

The main problem with this building is that it only applies to things that duplicants interact with manually

Turns out it applies to liquid bottles too, but this is impractical.

The fix: add a liquid input and output so you can use it instead of chlorine decontamination rooms from your bathroom.

Except that really doesn't matter.

## Space Heater ✔️

This building doesn't transfer its heat to air fast enough and produces too little heat per Watt,
so it is generally only good as a temporary quick and dirty heating solution...
except that a kiln is more practical most of the time.

* Decrease Power consumption to 90W
* Increase heat output to 80 kDTU/s (incidentally, this is the opposite of the AETN)
* Increase overheat temperature to 175C

## Thermo Regulator ✔️

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


## Automation ❌

No complaints here. Works as expected.

## Rocketry

Needs further analysis. Tweaks would be different in base game vs spaced out.

## Radiation Lamp ❔

There's basically no reason to use this building, ever.

5 Wheezeworts in a V-shape produce WAY more radiation without electricity,
provided you have a safe way to feed them phosphorite or can plant them with pips.

This probably means nerfing the radiation output of Wheezeworts

---

# Crops

## Waterweed

Not really worth the effort unless you have mushrooms and a gas range.

It's not particularly difficult to domesticate, however it is still costly due to the bleach stone requirements.
Squeaky pufts and a chlorine geyser are necessary to produce waterweed sustainably.

Raw lettuce isn't very good and the only recipes requiring it are made in the Gas Range.

## Nosh Bean

Huge hassle to domesticate for minimal benefit. You would only ever do it to flex.

The ethanol requirements must be supported by an arbor tree farm, you need to keep the farm cool,
and for all that hassle, you still have to combine it with pincha peppernut to get a decent morale.

## Arbor Tree ❌

Arbor trees do not need to change, as the petroleum generator's reduced pwater output compensates
for the ethanol distiller's ethanol output.

---

# Ranching

## Pufts and Slicksters

They don't eat gases fast enough, so scaling them up ends up being utterly impractical.


## Starvation Ranching

I am uncertain whether I want to make starvation ranching unviable as a food source, particularly for shove voles.

---

# Morale Issues

There are a lot of no-brainer sources of easy morale that make it far too easy to skill up your dupes

## Great Hall 🌙

The Great Hall bonus is far too easy to obtain for its incredible +6 morale bonus.
The simplest way to get it is to add a disabled water cooler and a decorative plant to a mess hall.

Changes:
- Art buff / plant nerf fixes the Decor 20+ item constraint being too easy to satisfy
- Now requires light source
- Reduce morale bonus of Great Hall to +3 and Mess Hall to +1

Proposed: (if possible)
- Recreational building must be active for the requirement to be met (if possible)
- Now requires ration box or fridge

## Parks and Nature Reserves ✔️

The conditions are fine, but the bonus is too big considering some of the clever ways you can get
these bonuses and trick dupes into walking through them.
(e.g. put one in the kitchen, put one next to bedrooms/bathrooms, put one in the main shaft, etc...)

Morale buff reduced to +2 and +4, respectively

## Barbecue ✔️

Barbecue provides +8 morale as a byproduct of ranching (which has other substantial benefits that justify ranching on their own.)

Baby critters provide the same amount of meat as adults, making drowning chambers the most straightforward way to produce meat.

Changed:
- Barbecue food quality reduced from 3 to 2 (same as omelette, but more calorie efficient)
- The food morale tweaks below

Proposed:
- Baby critters (first 5 cycles of life) produce 1/4 the amount of meat as adults.

## Fish ✔️

Fish has a similar problem to barbecue if you properly cheese their reproduction mechanics,
though they pretty much only get you food, lime, and radiation resistance.

Changes:
- Food quality of raw fish reduced to 1 (from 2)


## Food Quality vs Morale Bonus ✔️

Food morale is out of control. The morale curve is just crazy and needs to be toned down:

* -1: -1
*  0: 0
*  1: 1
*  2: 2 (from 4)
*  3: 4 (from 8)
*  4: 7 (from 12)
*  5+: 10 (from 16)

