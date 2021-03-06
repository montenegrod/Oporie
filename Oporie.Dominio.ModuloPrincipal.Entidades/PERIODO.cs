//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios en este archivo pueden ocasionar un comportamiento incorrecto y se perderán si
//     el código se vuelve a generar.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
using Capas.Dominio.Core.Entidades;

namespace Oporie.Dominio.ModuloPrincipal.Entidades
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(COLEGIATURA))]
    [KnownType(typeof(MATRICULA))]
    public partial class PERIODO: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Propiedades primitivas
    
        [DataMember]
        public System.Guid ID_PERIODO
        {
            get { return _iD_PERIODO; }
            set
            {
                if (_iD_PERIODO != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("La propiedad 'ID_PERIODO' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.");
                    }
                    _iD_PERIODO = value;
                    OnPropertyChanged("ID_PERIODO");
                }
            }
        }
        private System.Guid _iD_PERIODO;
    
        [DataMember]
        public System.DateTime PER_FECHAINICIO
        {
            get { return _pER_FECHAINICIO; }
            set
            {
                if (_pER_FECHAINICIO != value)
                {
                    _pER_FECHAINICIO = value;
                    OnPropertyChanged("PER_FECHAINICIO");
                }
            }
        }
        private System.DateTime _pER_FECHAINICIO;
    
        [DataMember]
        public System.DateTime PER_FECHAFIN
        {
            get { return _pER_FECHAFIN; }
            set
            {
                if (_pER_FECHAFIN != value)
                {
                    _pER_FECHAFIN = value;
                    OnPropertyChanged("PER_FECHAFIN");
                }
            }
        }
        private System.DateTime _pER_FECHAFIN;
    
        [DataMember]
        public bool PER_ESTADO
        {
            get { return _pER_ESTADO; }
            set
            {
                if (_pER_ESTADO != value)
                {
                    _pER_ESTADO = value;
                    OnPropertyChanged("PER_ESTADO");
                }
            }
        }
        private bool _pER_ESTADO;

        #endregion
        #region Propiedades de navegación
    
        [DataMember]
        public TrackableCollection<COLEGIATURA> COLEGIATURA
        {
            get
            {
                if (_cOLEGIATURA == null)
                {
                    _cOLEGIATURA = new TrackableCollection<COLEGIATURA>();
                    _cOLEGIATURA.CollectionChanged += FixupCOLEGIATURA;
                }
                return _cOLEGIATURA;
            }
            set
            {
                if (!ReferenceEquals(_cOLEGIATURA, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking");
                    }
                    if (_cOLEGIATURA != null)
                    {
                        _cOLEGIATURA.CollectionChanged -= FixupCOLEGIATURA;
                    }
                    _cOLEGIATURA = value;
                    if (_cOLEGIATURA != null)
                    {
                        _cOLEGIATURA.CollectionChanged += FixupCOLEGIATURA;
                    }
                    OnNavigationPropertyChanged("COLEGIATURA");
                }
            }
        }
        private TrackableCollection<COLEGIATURA> _cOLEGIATURA;
    
        [DataMember]
        public TrackableCollection<MATRICULA> MATRICULA
        {
            get
            {
                if (_mATRICULA == null)
                {
                    _mATRICULA = new TrackableCollection<MATRICULA>();
                    _mATRICULA.CollectionChanged += FixupMATRICULA;
                }
                return _mATRICULA;
            }
            set
            {
                if (!ReferenceEquals(_mATRICULA, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking");
                    }
                    if (_mATRICULA != null)
                    {
                        _mATRICULA.CollectionChanged -= FixupMATRICULA;
                    }
                    _mATRICULA = value;
                    if (_mATRICULA != null)
                    {
                        _mATRICULA.CollectionChanged += FixupMATRICULA;
                    }
                    OnNavigationPropertyChanged("MATRICULA");
                }
            }
        }
        private TrackableCollection<MATRICULA> _mATRICULA;

        #endregion
        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected virtual void ClearNavigationProperties()
        {
            COLEGIATURA.Clear();
            MATRICULA.Clear();
        }

        #endregion
        #region Corrección de asociación
    
        private void FixupCOLEGIATURA(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (COLEGIATURA item in e.NewItems)
                {
                    item.PERIODO = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("COLEGIATURA", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (COLEGIATURA item in e.OldItems)
                {
                    if (ReferenceEquals(item.PERIODO, this))
                    {
                        item.PERIODO = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("COLEGIATURA", item);
                    }
                }
            }
        }
    
        private void FixupMATRICULA(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (MATRICULA item in e.NewItems)
                {
                    item.PERIODO = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("MATRICULA", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (MATRICULA item in e.OldItems)
                {
                    if (ReferenceEquals(item.PERIODO, this))
                    {
                        item.PERIODO = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("MATRICULA", item);
                    }
                }
            }
        }

        #endregion
    }
}
