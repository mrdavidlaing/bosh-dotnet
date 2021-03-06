﻿// -----------------------------------------------------------------------
// <copyright file="FileMatcher.cs" company="Uhuru Software, Inc.">
// Copyright (c) 2011 Uhuru Software, Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

namespace Uhuru.BOSH.Agent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
using System.IO;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class FileMatcher
    {
        ////class FileMatcher
        ////  attr_writer :globs

        ////  def initialize(base_dir)
        ////    @base_dir = base_dir
        ////  end

        ////  def base_dir
        ////    @base_dir
        ////  end

        ////  def globs
        ////    @globs || default_globs
        ////  end

        ////  def default_globs
        ////    []
        ////  end
        ////end

        ////class AgentLogMatcher < FileMatcher
        ////  def base_dir
        ////    File.join(@base_dir, "bosh", "log")
        ////  end

        ////  def default_globs
        ////    [ "**/*" ]
        ////  end
        ////end

        ////class JobLogMatcher < FileMatcher
        ////  def base_dir
        ////    File.join(@base_dir, "sys", "log")
        ////  end

        ////  def default_globs
        ////    [ "**/*.log" ]
        ////  end
        ////end

        internal string baseDir;
        private IEnumerable<string> globs;

        public FileMatcher(string baseDir)
        {
            this.baseDir = baseDir;
        }
        public virtual string BaseDir
        {
            get
            {
                return baseDir;
            }
        }

        public virtual IEnumerable<string> Globs {
            
            set
            {       
                globs = value;
            }
            get
            {
                if (globs != null)
                    return globs;
                else
                    return new List<string>();
            }
        }
    }

    class JobLogMatcher : FileMatcher
    {
        public JobLogMatcher(string baseDir): base(baseDir)
        {

        }

        public override string BaseDir
        {
            get
            {
                return Path.Combine(baseDir, "bosh", "log");
            }
        }

        public override IEnumerable<string> Globs
        {
            get
            {
                return new List<string>() { "**/*" };
            }
        }
    }

    class AgentLogMatcher : FileMatcher
    {
        public AgentLogMatcher(string baseDir) : base(baseDir)
        {
        
        }

        public override string BaseDir
        {
            get
            {
                return Path.Combine(baseDir, "sys", "log");
            }
        }

        public override IEnumerable<string> Globs
        {
            get
            {
                return new List<string>(){ "**/*.log"};
            }
        }
             
    }
}
