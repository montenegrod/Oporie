﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Data.Objects.DataClasses;
using System.Data.Objects;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

using Infraestructura.Data.Core;
using Oporie.Dominio.ModuloPrincipal.Entidades;

namespace Oporie.Infraestructura.Data.ModuloPrincipal
{
    
    public interface IModuloPrincipalModel :IQueryableContext
    {
    
        #region ObjectSet Properties
    
        IObjectSet<ALUMNO> ALUMNO{get;}
        
    
        IObjectSet<ENTORNO_FAMILIAR> ENTORNO_FAMILIAR{get;}
        
    
        IObjectSet<PERSONA> PERSONA{get;}
        
    
        IObjectSet<REPRESENTANTE> REPRESENTANTE{get;}
        
    
        IObjectSet<REPRESENTANTE_LEGAL> REPRESENTANTE_LEGAL{get;}
        
    
        IObjectSet<AREA_GEOGRAFICA> AREA_GEOGRAFICA{get;}
        
    
        IObjectSet<CARGO> CARGO{get;}
        
    
        IObjectSet<CODIGOS> CODIGOS{get;}
        
    
        IObjectSet<HORARIO> HORARIO{get;}
        
    
        IObjectSet<PARENTESCO> PARENTESCO{get;}
        
    
        IObjectSet<PERIODO> PERIODO{get;}
        
    
        IObjectSet<REFERENCIA> REFERENCIA{get;}
        
    
        IObjectSet<REQUISITO> REQUISITO{get;}
        
    
        IObjectSet<TELEFONO> TELEFONO{get;}
        
    
        IObjectSet<COLEGIATURA> COLEGIATURA{get;}
        
    
        IObjectSet<INSCRIPCION> INSCRIPCION{get;}
        
    
        IObjectSet<MATRICULA> MATRICULA{get;}
        
    
        IObjectSet<REQUISITOS_MATRICULA> REQUISITOS_MATRICULA{get;}
        

        #endregion

    
    }
}
	