using IniParserLTK;
using Microsoft.Xna.Framework.Storage;
using System;
using System.IO;

namespace GrobEngine
{
	public class Storage
	{
		public static StorageContainer OpenUserContainerData()
        {
			IAsyncResult result;

			result = StorageDevice.BeginShowSelector(null, null);
			StorageDevice device = StorageDevice.EndShowSelector(result);

			result = device.BeginOpenContainer("SaveData", null, null);
			StorageContainer container = device.EndOpenContainer(result);
			return container;
		}

		public static string ConfigINI(string iniFile, string section, string setting, string val = "")
		{
			StorageContainer container = OpenUserContainerData();
			string result = "";

			if (!string.IsNullOrWhiteSpace(val))
			{
				IniParser parser = new IniParser();

				if (container.FileExists(iniFile))
				{
					using (Stream stream = container.OpenFile(iniFile, FileMode.Open, FileAccess.Read, FileShare.None))
					{
						using (var reader = new StreamReader(stream))
						{
							parser.Read(reader);
						}
					}

					container.DeleteFile(iniFile);
				}

				using (Stream stream = container.CreateFile(iniFile))
				{
					using (var streamWriter = new StreamWriter(stream))
					{
						if (!parser.HasSection(section))
						{
							parser.AddSection(section);
						}

						if (!parser.HasSetting(section, setting))
						{
							parser.AddSetting(section, setting, val);
						}
						else
						{
							string curSetting = parser.GetSetting(section, setting);
							if (!curSetting.Equals(setting))
							{
								parser.DeleteSetting(section, setting);
								parser.AddSetting(section, setting, val);
							}
						}

						string newINI = parser.ToString();
						streamWriter.Write(newINI);
					}
				}
			}
			else
			{
				if (container.FileExists(iniFile))
				{
					using (Stream stream = container.OpenFile(iniFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
					{
						IniParser parser = new IniParser();

						using (var reader = new StreamReader(stream))
						{
							parser.Read(reader);
						}

						if (parser.HasSetting(section, setting) && parser.HasSetting(section, setting))
						{
							result = parser.GetSetting(section, setting);
						}
					}
				}
			}

			container.Dispose();
			return result;
		}
	}
}
