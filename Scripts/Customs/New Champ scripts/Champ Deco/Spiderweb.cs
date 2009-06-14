using System;
using Server;

namespace Server.Items
{
    public class Spiderweb : Item
    {
        public override int LabelNumber { get { return 1023814; } } // spiderweb
	
		[Constructable]
		public Spiderweb() : base( 0x10DD )
		{
			Weight = 1.0;			
		}

        public Spiderweb(Serial serial)
            : base(serial)
		{
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
    public class CocoonWeb : BaseAddon
    {
        public override BaseAddonDeed Deed { get { return new CocoonWebDeed(); } }
        [Constructable]
        public CocoonWeb()
        {
            AddComponent(new AddonComponent(0x10DD), 0, 0, 0);
            AddComponent(new AddonComponent(0x10DA), 0, 0, 0);
        }

        public CocoonWeb(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class CocoonWebDeed : BaseAddonDeed
    {
        public override BaseAddon Addon { get { return new CocoonWeb(); } }

        [Constructable]
        public CocoonWebDeed()
        {
            Name = "Cocoon with Spiderweb Deed";
        }

        public CocoonWebDeed(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}