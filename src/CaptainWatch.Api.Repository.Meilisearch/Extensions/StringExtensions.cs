namespace CaptainWatch.Api.Repository.Melisearch.Extensions
{
	public static class StringExtensions
	{

		public static string ToLowerFirst(this string str)
		{
			if (string.IsNullOrEmpty(str)) return str;
			return char.ToLower(str[0]) + str.Substring(1);
		}
	}
}
