// Copyright SCIEX 2017. All rights reserved.

using System;
using Illumina.BaseSpace.SDK;
using Illumina.BaseSpace.SDK.ServiceModels;
using Illumina.BaseSpace.SDK.Types;


namespace BSTestConsole
{
	public class BaseSpaceDataProvider 
	{
		private readonly BaseSpaceClient _baseSpaceClient;
		private readonly BaseSpaceClientSettings _settings;
		private readonly string _accessToken;

		public BaseSpaceDataProvider(string accessToken)
		{
			_accessToken = accessToken;
			_settings = new BaseSpaceClientSettings
			{
				Authentication = new OAuth2Authentication(accessToken),
				RetryAttempts = 1,
				TimeoutMin = 1
			};
			_baseSpaceClient = new BaseSpaceClient(_settings);
		}


		public ProjectCompact[] GetProjects()
		{
			ProjectCompact[] lpr;
			try
			{
				 lpr = _baseSpaceClient.ListProjects(new ListProjectsRequest { Limit = 100 })
					.Response.Items;
			}
			catch (Exception ex)
			{
				throw new Exception(
					"Failed to connect to BaseSpace to download the necessary files.  Please try again later.", ex);
			}
			return lpr;
		}
	}
}
