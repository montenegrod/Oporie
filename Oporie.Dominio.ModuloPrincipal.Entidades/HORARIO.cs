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
    public partial class HORARIO: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Propiedades primitivas
    
        [DataMember]
        public System.Guid ID_HORARIO
        {
            get { return _iD_HORARIO; }
            set
            {
                if (_iD_HORARIO != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("La propiedad 'ID_HORARIO' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.");
                    }
                    _iD_HORARIO = value;
                    OnPropertyChanged("ID_HORARIO");
                }
            }
        }
        private System.Guid _iD_HORARIO;
    
        [DataMember]
        public string HOR_DESCRIPCION
        {
            get { return _hOR_DESCRIPCION; }
            set
            {
                if (_hOR_DESCRIPCION != value)
                {
                    _hOR_DESCRIPCION = value;
                    OnPropertyChanged("HOR_DESCRIPCION");
                }
            }
        }
        private string _hOR_DESCRIPCION;
    
        [DataMember]
        public bool HOR_ESTADO
        {
            get { return _hOR_ESTADO; }
            set
            {
                if (_hOR_ESTADO != value)
                {
                    _hOR_ESTADO = value;
                    OnPropertyChanged("HOR_ESTADO");
                }
            }
        }
        private bool _hOR_ESTADO;

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
                    item.HORARIO = this;
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
                    if (ReferenceEquals(item.HORARIO, this))
                    {
                        item.HORARIO = null;
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
                    item.HORARIO = this;
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
                    if (ReferenceEquals(item.HORARIO, this))
                    {
                        item.HORARIO = null;
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
