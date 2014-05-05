using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Foodstuff
{
    public class Ingredient : IComparable<Ingredient>
    {
        //public int Integer { get; private set; }
        //public Fraction Fraction { get; private set; }
        //public Unit Unit { get; private set; }
        public string Quantity { get; private set; }
        public string Item { get; private set; }

        //public Ingredient(int integer, Fraction fraction, Unit unit, string item)
        //{
        //this.Integer = integer;
        //this.Fraction = fraction;
        //this.Unit = unit;
        //this.Item = item;
        //}

        public Ingredient(string quantity, string item)
        {
            this.Quantity = quantity;
            this.Item = item;
        }

        public override string ToString()
        {
            return string.Join(" ", this.Quantity, this.Item);
            //return string.Format("{0}{1}{2}{3}", this.Integer != 0 ? string.Format("{0} ", this.Integer) : string.Empty, this.Fraction.Value != Fractions.Zero ? string.Format("{0} ", this.Fraction.FancyString) : string.Empty, this.Unit.Value != Units.Unit ? string.Format("{0} ", this.Unit.Abbreviation) : string.Empty, this.Item);
        }

        public int CompareTo(Ingredient other)
        {
            if (other == null) return 1;
            return this.Item.CompareTo(other.Item);
        }

        public string ToXml()
        {
            using (StringWriter ret = new StringWriter())
            {
                using (XmlTextWriter writer = new XmlTextWriter(ret))
                {
                    writer.WriteStartElement("ingredient");
                    //writer.WriteAttributeString("integer", this.Integer.ToString());
                    //writer.WriteAttributeString("fraction", this.Fraction.Value.ToString());
                    //writer.WriteAttributeString("unit", this.Unit.Value.ToString());
                    writer.WriteAttributeString("quantity", this.Quantity);
                    writer.WriteAttributeString("item", this.Item);
                    writer.WriteEndElement();
                }
                return ret.ToString();
            }
        }

        public static Ingredient FromXml(XmlNode node)
        {
            //if (node.Name.ToLower() != "ingredient" || node.Attributes["integer"] == null || node.Attributes["item"] == null)
            if (node.Name.ToLower() != "ingredient" || node.Attributes["quantity"] == null || node.Attributes["item"] == null)
            {
                return null;
            }
            return new Ingredient(node.Attributes["quantity"].InnerText, node.Attributes["item"].InnerText);
            //return new Ingredient(int.Parse(node["integer"].InnerText), GetFraction(node.Attributes["fraction"] != null ? (Fractions)Enum.Parse(typeof(Fractions), node.Attributes["fraction"].InnerText, true) : Fractions.Zero), GetUnit(node.Attributes["unit"] != null ? (Units)Enum.Parse(typeof(Units), node.Attributes["unit"].InnerText, true) : Units.Unit), node.Attributes["item"].InnerText);
        }

        public static Fraction GetFraction(Fractions fraction)
        {
            switch (fraction)
            {
                case Fractions.Zero:
                default:
                    return new Fraction { PlainString = string.Empty, FancyString = string.Empty, Value = Fractions.Zero, DoubleValue = 0 };
                case Fractions.OneEighth:
                    return new Fraction { PlainString = "1/8", FancyString = "⅛", Value = Fractions.OneEighth, DoubleValue = 0.125 };
                case Fractions.OneQuarter:
                    return new Fraction { PlainString = "1/4", FancyString = "¼", Value = Fractions.OneQuarter, DoubleValue = 0.25 };
                case Fractions.OneThird:
                    return new Fraction { PlainString = "1/3", FancyString = "⅓", Value = Fractions.OneThird, DoubleValue = 0.333 };
                case Fractions.ThreeEighths:
                    return new Fraction { PlainString = "3/8", FancyString = "⅜", Value = Fractions.ThreeEighths, DoubleValue = 0.375 };
                case Fractions.OneHalf:
                    return new Fraction { PlainString = "1/2", FancyString = "½", Value = Fractions.OneHalf, DoubleValue = 0.5 };
                case Fractions.FiveEighths:
                    return new Fraction { PlainString = "5/8", FancyString = "⅝", Value = Fractions.FiveEighths, DoubleValue = 0.625 };
                case Fractions.TwoThirds:
                    return new Fraction { PlainString = "2/3", FancyString = "⅔", Value = Fractions.TwoThirds, DoubleValue = 0.666 };
                case Fractions.ThreeQuarters:
                    return new Fraction { PlainString = "3/4", FancyString = "¾", Value = Fractions.ThreeQuarters, DoubleValue = 0.75 };
                case Fractions.SevenEighths:
                    return new Fraction { PlainString = "7/8", FancyString = "⅞", Value = Fractions.SevenEighths, DoubleValue = 0.875 };
            }
        }

        public static IEnumerable<Fraction> GetFractions()
        {
            foreach (Fractions fraction in Enum.GetValues(typeof(Fractions)))
            {
                yield return GetFraction(fraction);
            }
        }

        public static Unit GetUnit(Units unit)
        {
            switch (unit)
            {
                case Units.Unit:
                default:
                    return new Unit { Value = Units.Unit, Abbreviation = string.Empty };
                case Units.Teaspoon:
                    return new Unit { Value = Units.Teaspoon, Abbreviation = "tsp." };
                case Units.Tablespoon:
                    return new Unit { Value = Units.Tablespoon, Abbreviation = "tbsp." };
                case Units.Cup:
                    return new Unit { Value = Units.Cup, Abbreviation = "cup" };
                case Units.Pint:
                    return new Unit { Value = Units.Pint, Abbreviation = "pt." };
                case Units.Quart:
                    return new Unit { Value = Units.Quart, Abbreviation = "qt." };
                case Units.Gallon:
                    return new Unit { Value = Units.Gallon, Abbreviation = "gal." };
                case Units.FluidOunce:
                    return new Unit { Value = Units.FluidOunce, Abbreviation = "fl oz." };
                case Units.Pound:
                    return new Unit { Value = Units.Pound, Abbreviation = "lb." };
            }
        }

        public static IEnumerable<Unit> GetUnits()
        {
            foreach (Units unit in Enum.GetValues(typeof(Units)))
            {
                yield return GetUnit(unit);
            }
        }
    }

    public struct Fraction
    {
        public string PlainString { get; set; }
        public string FancyString { get; set; }
        public Fractions Value { get; set; }
        public double DoubleValue { get; set; }

        public override string ToString()
        {
            return this.PlainString;
        }
    }

    public enum Fractions
    {
        Zero,
        OneEighth,
        OneQuarter,
        OneThird,
        ThreeEighths,
        OneHalf,
        FiveEighths,
        TwoThirds,
        ThreeQuarters,
        SevenEighths
    }

    public struct Unit
    {
        public Units Value { get; set; }
        public string Abbreviation { get; set; }

        public override string ToString()
        {
            return this.Abbreviation;
        }
    }

    public enum Units
    {
        Unit,
        Teaspoon,
        Tablespoon,
        Cup,
        Pint,
        Quart,
        Gallon,
        FluidOunce,
        Pound
    }
}
