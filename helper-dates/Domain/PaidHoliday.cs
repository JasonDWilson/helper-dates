using jwpro.DateHelper.Enums;
using jwpro.DateHelper.Helpers;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Threading.Tasks;

namespace jwpro.DateHelper.Domain
{
	public class PaidHoliday
	{
		private string _dateCalculationString;
		private string _name;

		public PaidHoliday()
		{
		}
		public PaidHoliday(SpecialDate associatedSpecial) { AssociatedSpecialDate = associatedSpecial; }

		public PaidHoliday(string name, Func<string, DateTime> dateCalculation)
		{
			Name = name;
			DateCalculation = dateCalculation;
		}

		public PaidHoliday(string name, SpecialDate relatedSpecial, int relatedSpecialOffset)
		{
			Name = name;
			RelatedSpecialDate = relatedSpecial;
			RelatedSpecialDateOffset = relatedSpecialOffset;
		}


		public DateTime? GetDate(string year = null)
		{
			// make sure year is provided
			if(string.IsNullOrWhiteSpace(year))
			{
				year = DateTime.Now.Year.ToString();
			}

			// use related special date as override
			if((RelatedSpecialDate != 0) && (RelatedSpecialDate != SpecialDate.Custom))
			{
				DateCalculation = (string y) => SpecialDateHelper.GetSpecialDate(RelatedSpecialDate, y)
					.AddDays(RelatedSpecialDateOffset);
			}

			if(DateCalculation != null)
			{
				return DateCalculation.Invoke(year);
			}
			else if(AssociatedSpecialDate != SpecialDate.Custom)
			{
				return SpecialDateHelper.GetSpecialDate(AssociatedSpecialDate, year);
			}

			return null;
		}

		public SpecialDate AssociatedSpecialDate { get; set; }

		public Func<string, DateTime> DateCalculation { get; set; }

		public string DateCalculationString
		{
			get { return _dateCalculationString; }
			set
			{
				ScriptOptions options = ScriptOptions.Default.AddReferences("System").AddImports("System");
				Task<Func<string, DateTime>> task = CSharpScript.EvaluateAsync<Func<string, DateTime>>(value, options);
				DateCalculation = task.GetAwaiter().GetResult();
				_dateCalculationString = value;
			}
		}

		public string Name
		{
			get
			{
				if(string.IsNullOrWhiteSpace(_name))
				{
					_name = AssociatedSpecialDate.ToString().Replace("_", " ");
				}

				return _name;
			}
			set { _name = value; }
		}

		public SpecialDate RelatedSpecialDate { get; set; }

		public int RelatedSpecialDateOffset { get; set; }
	}
}
