﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pharmacy.linq
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Mapping")]
	public partial class MapClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void OnCreated()
    {
        base.ObjectTrackingEnabled = false;
        base.CommandTimeout = 180;
        //throw new NotImplementedException();
    }
    partial void InsertCSS_MasterSiteDrugName(CSS_MasterSiteDrugName instance);
    partial void UpdateCSS_MasterSiteDrugName(CSS_MasterSiteDrugName instance);
    partial void DeleteCSS_MasterSiteDrugName(CSS_MasterSiteDrugName instance);
    partial void InsertCSS_MasterSiteDrugUnit(CSS_MasterSiteDrugUnit instance);
    partial void UpdateCSS_MasterSiteDrugUnit(CSS_MasterSiteDrugUnit instance);
    partial void DeleteCSS_MasterSiteDrugUnit(CSS_MasterSiteDrugUnit instance);
    partial void InsertCSS_MasterSiteRoute(CSS_MasterSiteRoute instance);
    partial void UpdateCSS_MasterSiteRoute(CSS_MasterSiteRoute instance);
    partial void DeleteCSS_MasterSiteRoute(CSS_MasterSiteRoute instance);
    partial void InsertCSS_MasterRepeatPattern(CSS_MasterRepeatPattern instance);
    partial void UpdateCSS_MasterRepeatPattern(CSS_MasterRepeatPattern instance);
    partial void DeleteCSS_MasterRepeatPattern(CSS_MasterRepeatPattern instance);
    #endregion
		
		public MapClassesDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["MappingConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MapClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MapClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MapClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MapClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<CSS_MasterSiteDrugName> CSS_MasterSiteDrugNames
		{
			get
			{
				return this.GetTable<CSS_MasterSiteDrugName>();
			}
		}
		
		public System.Data.Linq.Table<CSS_MasterSiteDrugUnit> CSS_MasterSiteDrugUnits
		{
			get
			{
				return this.GetTable<CSS_MasterSiteDrugUnit>();
			}
		}
		
		public System.Data.Linq.Table<CSS_MasterSiteRoute> CSS_MasterSiteRoutes
		{
			get
			{
				return this.GetTable<CSS_MasterSiteRoute>();
			}
		}
		
		public System.Data.Linq.Table<CSS_MasterRepeatPattern> CSS_MasterRepeatPatterns
		{
			get
			{
				return this.GetTable<CSS_MasterRepeatPattern>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CSS_MasterSiteDrugName")]
	public partial class CSS_MasterSiteDrugName : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MasterSiteDrugNameId;
		
		private string _MasterSiteDrugName;
		
		private string _MasterMappedPharmacyDrug;
		
		private System.DateTime _InsertedLDT;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMasterSiteDrugNameIdChanging(int value);
    partial void OnMasterSiteDrugNameIdChanged();
    partial void OnMasterSiteDrugNameChanging(string value);
    partial void OnMasterSiteDrugNameChanged();
    partial void OnMasterMappedPharmacyDrugChanging(string value);
    partial void OnMasterMappedPharmacyDrugChanged();
    partial void OnInsertedLDTChanging(System.DateTime value);
    partial void OnInsertedLDTChanged();
    #endregion
		
		public CSS_MasterSiteDrugName()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MasterSiteDrugNameId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MasterSiteDrugNameId
		{
			get
			{
				return this._MasterSiteDrugNameId;
			}
			set
			{
				if ((this._MasterSiteDrugNameId != value))
				{
					this.OnMasterSiteDrugNameIdChanging(value);
					this.SendPropertyChanging();
					this._MasterSiteDrugNameId = value;
					this.SendPropertyChanged("MasterSiteDrugNameId");
					this.OnMasterSiteDrugNameIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MasterSiteDrugName", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string MasterSiteDrugName
		{
			get
			{
				return this._MasterSiteDrugName;
			}
			set
			{
				if ((this._MasterSiteDrugName != value))
				{
					this.OnMasterSiteDrugNameChanging(value);
					this.SendPropertyChanging();
					this._MasterSiteDrugName = value;
					this.SendPropertyChanged("MasterSiteDrugName");
					this.OnMasterSiteDrugNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MasterMappedPharmacyDrug", DbType="VarChar(200)")]
		public string MasterMappedPharmacyDrug
		{
			get
			{
				return this._MasterMappedPharmacyDrug;
			}
			set
			{
				if ((this._MasterMappedPharmacyDrug != value))
				{
					this.OnMasterMappedPharmacyDrugChanging(value);
					this.SendPropertyChanging();
					this._MasterMappedPharmacyDrug = value;
					this.SendPropertyChanged("MasterMappedPharmacyDrug");
					this.OnMasterMappedPharmacyDrugChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InsertedLDT", DbType="SmallDateTime NOT NULL")]
		public System.DateTime InsertedLDT
		{
			get
			{
				return this._InsertedLDT;
			}
			set
			{
				if ((this._InsertedLDT != value))
				{
					this.OnInsertedLDTChanging(value);
					this.SendPropertyChanging();
					this._InsertedLDT = value;
					this.SendPropertyChanged("InsertedLDT");
					this.OnInsertedLDTChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CSS_MasterSiteDrugUnit")]
	public partial class CSS_MasterSiteDrugUnit : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MasterSiteDrugUnitId;
		
		private string _MasterSiteDrugUnit;
		
		private string _MasterMappedPharmacyUnit;
		
		private System.DateTime _InsertedLDT;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMasterSiteDrugUnitIdChanging(int value);
    partial void OnMasterSiteDrugUnitIdChanged();
    partial void OnMasterSiteDrugUnitChanging(string value);
    partial void OnMasterSiteDrugUnitChanged();
    partial void OnMasterMappedPharmacyUnitChanging(string value);
    partial void OnMasterMappedPharmacyUnitChanged();
    partial void OnInsertedLDTChanging(System.DateTime value);
    partial void OnInsertedLDTChanged();
    #endregion
		
		public CSS_MasterSiteDrugUnit()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MasterSiteDrugUnitId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MasterSiteDrugUnitId
		{
			get
			{
				return this._MasterSiteDrugUnitId;
			}
			set
			{
				if ((this._MasterSiteDrugUnitId != value))
				{
					this.OnMasterSiteDrugUnitIdChanging(value);
					this.SendPropertyChanging();
					this._MasterSiteDrugUnitId = value;
					this.SendPropertyChanged("MasterSiteDrugUnitId");
					this.OnMasterSiteDrugUnitIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MasterSiteDrugUnit", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string MasterSiteDrugUnit
		{
			get
			{
				return this._MasterSiteDrugUnit;
			}
			set
			{
				if ((this._MasterSiteDrugUnit != value))
				{
					this.OnMasterSiteDrugUnitChanging(value);
					this.SendPropertyChanging();
					this._MasterSiteDrugUnit = value;
					this.SendPropertyChanged("MasterSiteDrugUnit");
					this.OnMasterSiteDrugUnitChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MasterMappedPharmacyUnit", DbType="VarChar(50)")]
		public string MasterMappedPharmacyUnit
		{
			get
			{
				return this._MasterMappedPharmacyUnit;
			}
			set
			{
				if ((this._MasterMappedPharmacyUnit != value))
				{
					this.OnMasterMappedPharmacyUnitChanging(value);
					this.SendPropertyChanging();
					this._MasterMappedPharmacyUnit = value;
					this.SendPropertyChanged("MasterMappedPharmacyUnit");
					this.OnMasterMappedPharmacyUnitChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InsertedLDT", DbType="SmallDateTime NOT NULL")]
		public System.DateTime InsertedLDT
		{
			get
			{
				return this._InsertedLDT;
			}
			set
			{
				if ((this._InsertedLDT != value))
				{
					this.OnInsertedLDTChanging(value);
					this.SendPropertyChanging();
					this._InsertedLDT = value;
					this.SendPropertyChanged("InsertedLDT");
					this.OnInsertedLDTChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CSS_MasterSiteRoute")]
	public partial class CSS_MasterSiteRoute : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MasterSiteRouteId;
		
		private string _MasterSiteRouteCode;
		
		private string _MasterMappedPharmacyRoute;
		
		private System.DateTime _InsertedLDT;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMasterSiteRouteIdChanging(int value);
    partial void OnMasterSiteRouteIdChanged();
    partial void OnMasterSiteRouteCodeChanging(string value);
    partial void OnMasterSiteRouteCodeChanged();
    partial void OnMasterMappedPharmacyRouteChanging(string value);
    partial void OnMasterMappedPharmacyRouteChanged();
    partial void OnInsertedLDTChanging(System.DateTime value);
    partial void OnInsertedLDTChanged();
    #endregion
		
		public CSS_MasterSiteRoute()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MasterSiteRouteId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MasterSiteRouteId
		{
			get
			{
				return this._MasterSiteRouteId;
			}
			set
			{
				if ((this._MasterSiteRouteId != value))
				{
					this.OnMasterSiteRouteIdChanging(value);
					this.SendPropertyChanging();
					this._MasterSiteRouteId = value;
					this.SendPropertyChanged("MasterSiteRouteId");
					this.OnMasterSiteRouteIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MasterSiteRouteCode", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string MasterSiteRouteCode
		{
			get
			{
				return this._MasterSiteRouteCode;
			}
			set
			{
				if ((this._MasterSiteRouteCode != value))
				{
					this.OnMasterSiteRouteCodeChanging(value);
					this.SendPropertyChanging();
					this._MasterSiteRouteCode = value;
					this.SendPropertyChanged("MasterSiteRouteCode");
					this.OnMasterSiteRouteCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MasterMappedPharmacyRoute", DbType="VarChar(50)")]
		public string MasterMappedPharmacyRoute
		{
			get
			{
				return this._MasterMappedPharmacyRoute;
			}
			set
			{
				if ((this._MasterMappedPharmacyRoute != value))
				{
					this.OnMasterMappedPharmacyRouteChanging(value);
					this.SendPropertyChanging();
					this._MasterMappedPharmacyRoute = value;
					this.SendPropertyChanged("MasterMappedPharmacyRoute");
					this.OnMasterMappedPharmacyRouteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InsertedLDT", DbType="SmallDateTime NOT NULL")]
		public System.DateTime InsertedLDT
		{
			get
			{
				return this._InsertedLDT;
			}
			set
			{
				if ((this._InsertedLDT != value))
				{
					this.OnInsertedLDTChanging(value);
					this.SendPropertyChanging();
					this._InsertedLDT = value;
					this.SendPropertyChanged("InsertedLDT");
					this.OnInsertedLDTChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CSS_MasterRepeatPattern")]
	public partial class CSS_MasterRepeatPattern : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MasterRepeatPatternId;
		
		private string _MasterRepeatPatternCode;
		
		private string _MasterMappedRepeatPattern;
		
		private System.DateTime _InsertedLDT;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMasterRepeatPatternIdChanging(int value);
    partial void OnMasterRepeatPatternIdChanged();
    partial void OnMasterRepeatPatternCodeChanging(string value);
    partial void OnMasterRepeatPatternCodeChanged();
    partial void OnMasterMappedRepeatPatternChanging(string value);
    partial void OnMasterMappedRepeatPatternChanged();
    partial void OnInsertedLDTChanging(System.DateTime value);
    partial void OnInsertedLDTChanged();
    #endregion
		
		public CSS_MasterRepeatPattern()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MasterRepeatPatternId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MasterRepeatPatternId
		{
			get
			{
				return this._MasterRepeatPatternId;
			}
			set
			{
				if ((this._MasterRepeatPatternId != value))
				{
					this.OnMasterRepeatPatternIdChanging(value);
					this.SendPropertyChanging();
					this._MasterRepeatPatternId = value;
					this.SendPropertyChanged("MasterRepeatPatternId");
					this.OnMasterRepeatPatternIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MasterRepeatPatternCode", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string MasterRepeatPatternCode
		{
			get
			{
				return this._MasterRepeatPatternCode;
			}
			set
			{
				if ((this._MasterRepeatPatternCode != value))
				{
					this.OnMasterRepeatPatternCodeChanging(value);
					this.SendPropertyChanging();
					this._MasterRepeatPatternCode = value;
					this.SendPropertyChanged("MasterRepeatPatternCode");
					this.OnMasterRepeatPatternCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MasterMappedRepeatPattern", DbType="VarChar(50)")]
		public string MasterMappedRepeatPattern
		{
			get
			{
				return this._MasterMappedRepeatPattern;
			}
			set
			{
				if ((this._MasterMappedRepeatPattern != value))
				{
					this.OnMasterMappedRepeatPatternChanging(value);
					this.SendPropertyChanging();
					this._MasterMappedRepeatPattern = value;
					this.SendPropertyChanged("MasterMappedRepeatPattern");
					this.OnMasterMappedRepeatPatternChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InsertedLDT", DbType="SmallDateTime NOT NULL")]
		public System.DateTime InsertedLDT
		{
			get
			{
				return this._InsertedLDT;
			}
			set
			{
				if ((this._InsertedLDT != value))
				{
					this.OnInsertedLDTChanging(value);
					this.SendPropertyChanging();
					this._InsertedLDT = value;
					this.SendPropertyChanged("InsertedLDT");
					this.OnInsertedLDTChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
