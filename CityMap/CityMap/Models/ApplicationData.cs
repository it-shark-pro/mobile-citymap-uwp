using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CityMap.Models
{
	[DataContract()]
	public class ApplicationData
	{
		[JsonProperty]
		[DataMember(Name = "photos")]
		public IEnumerable<City> Cities { get; set; }
	}
}
