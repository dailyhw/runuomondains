using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
	public class ChannelingTheSupernaturalQuest : BaseQuest
	{   		
		public override bool DoneOnce{ get{ return true; } }
		
		/* Channeling the Supernatural */
		public override object Title{ get{ return 1078044; } }
		
		/* Head East out of town and go to Old Haven. Use Spirit Speak and channel energy from either yourself or nearby corpses 
		there. You can also cast Necromancy spells as well to raise Spirit Speak. Do these activities until you have raised your 
		Spirit Speak skill to 50.<br><center>------</center><br>How do you do? Channeling the supernatural through Spirit Speak 
		allows you heal your wounds. Such channeling expends your mana, so be mindful of this. Spirit Speak enhances the potency 
		of your Necromancy spells. The channeling powers of a Medium are quite useful when practicing the dark magic of Necromancy.
		<br><br>It is best to practice Spirit Speak where there are a lot of corpses. Head East out of town and go to Old Haven. 
		Undead currently reside there. Use Spirit Speak and channel energy from either yourself or nearby corpses. You can also 
		cast Necromancy spells as well to raise Spirit Speak.<br><br>Come back to me once you feel that you are worthy of the 
		rank of Apprentice Medium and I will reward you with something useful. */ 	
		public override object Description{ get{ return 1078047; } }
		
		/* Channeling the supernatural isn't for everyone. It is a dark art. See me if you ever wish to pursue the life of a Medium. */
		public override object Refuse{ get{ return 1078048; } }
		
		/* Back so soon? You have not achieved the rank of Apprentice Medium. Come back to me once you feel that you are worthy of 
		the rank of Apprentice Medium and I will reward you with something useful. */
		public override object Uncomplete{ get{ return 1078049; } }
		
		/* Well done! Channeling the supernatural is taxing, indeed. As promised, I will reward you with this bag of Necromancer 
		reagents. You will need these if you wish to also pursue the dark magic of Necromancy. Good journey to you. */
		public override object Complete{ get{ return 1078051; } }
		
		public ChannelingTheSupernaturalQuest() : base()
		{  		
			AddObjective( new ApprenticeObjective( SkillName.SpiritSpeak, 50, "Old Haven Training", 1078045, 1078046 ) );
			
			// 1078045 You ability to channel the supernatural is greatly enhanced while questing in this area.
			// 1078046 You are not in the quest area for Apprentice Medium. Your ability to channel the supernatural potential is not enhanced here.
		
			AddReward( new BaseReward( typeof( BagOfNecromancerReagents ), 1078053 ) );
		}
		
		public override bool CanOffer()
		{		
			return Owner.Skills.SpiritSpeak.Base < 50;
		}
		
		public override void OnCompleted()
		{			
			Owner.SendLocalizedMessage( 1078050, null, 0x23 ); // You have achieved the rank of Apprentice Medium. Return to Morganna in New Haven to receive your reward.
			Owner.PlaySound( CompleteSound );
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( (int) 0 ); // version
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			
			int version = reader.ReadInt();
		}  
	}
	
	public class Morganna : MondainQuester
	{
		public override Type[] Quests
		{ 
			get{ return new Type[] 
			{ 
				typeof( ChannelingTheSupernaturalQuest )
			};} 
		}  

		public override void InitSBInfo()
		{
			SBInfos.Add( new SBMage() );
		}
		
		[Constructable]
		public Morganna() : base( "Morganna", "The Spirit Speak Instructor" )
		{   
			SetSkill( SkillName.Magery, 65.0, 90.0 );
			SetSkill( SkillName.MagicResist, 65.0, 90.0 );
			SetSkill( SkillName.SpiritSpeak, 65.0, 90.0 );
			SetSkill( SkillName.Swords, 65.0, 90.0 );
			SetSkill( SkillName.Meditation, 65.0, 90.0 );
			SetSkill( SkillName.Necromancy, 65.0, 90.0 );
		}
		
		public Morganna( Serial serial ) : base( serial )
		{
		}  
		
		public override void Advertise()
		{
			Say( 1078132 ); // Want to learn how to channel the supernatural?
		}
		
		public override void OnOfferFailed()
		{			
			Say( 1077772 ); // I cannot teach you, for you know all I can teach!
		}
		
		public override void InitBody()
		{		
			Female = true;
			CantWalk = true;
			Race = Race.Human;	
		
			base.InitBody();
		}
		
		public override void InitOutfit()
		{
			AddItem( new Backpack() );
			AddItem( new Robe( 0x47D ) );
			AddItem( new SkullCap( 0x455 ) );
			AddItem( new Sandals() );
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( (int) 0 ); // version
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			
			int version = reader.ReadInt();
		} 
	}
}