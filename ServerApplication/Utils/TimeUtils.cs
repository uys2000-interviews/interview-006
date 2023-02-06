namespace ServerApplication.Utils;
public static class TimeUtils
{
	public static int Timestamp(DateTime date)
	{
		DateTime point = new DateTime(1970, 1, 1);
		TimeSpan time = date.Subtract(point);
		return (int)time.TotalSeconds;
	}

	public static int Timestamp()
	{
		return Timestamp(DateTime.UtcNow);
	}
}
