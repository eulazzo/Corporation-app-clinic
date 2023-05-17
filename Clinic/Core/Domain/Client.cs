﻿using System;

namespace Core.Domain;
public class Client
{
    public Guid Id { get; set; }
    public string Nome { get; set; } 
    public DateTime DataNascimento { get; set; }
    public Sexo Sexo { get; set; }  
    public ICollection<Telefone> Telefones { get; set; } 
    public string Documento { get; set; }  
    public DateTime Criacao { get; set; }
    public DateTime UltimaAtualizacao { get; set; }
    
    public Endereco Endereco { get; set; }

}
