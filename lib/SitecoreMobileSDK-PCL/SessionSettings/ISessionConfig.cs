﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sitecore.MobileSDK.SessionSettings
{
  public interface ISessionConfig
  {
    ISessionConfig SessionConfigShallowCopy();

    string InstanceUrl
    {
        get;
    }

    string Site      
    { 
        get; 
    }

    string ItemWebApiVersion
    {
        get;
    }

  	string MediaLybraryRoot
  	{
  		get;
  	}
  }
}
