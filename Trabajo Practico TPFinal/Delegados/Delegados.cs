﻿using System.Data;

/// <summary>
/// Delegado para manejar un evento que permite añadir items al deposito de compra
/// </summary>
/// <param name="fila"></param>
public delegate void AgregarAlDepositoDelegado(DataRow fila);
/// <summary>
/// Delegado para poder invocar el metodo MostrarPublicidad desde el hilo principal,
/// para poder actualizar el imageBox
/// </summary>
/// <param name="param"></param>
public delegate void DelegadoThreadConParam(object param);