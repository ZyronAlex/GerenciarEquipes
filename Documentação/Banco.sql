-- Gera��o de Modelo f�sico
-- Sql ANSI 2003 - brModelo.



CREATE TABLE Loja (
id_loja INTEGER PRIMARY KEY IDENTITY,
endereco VARCHAR(600),
telefone INTEGER,
nome VARCHAR(300),
email VARCHAR(300)
);

CREATE TABLE Admin (
nome VARCHAR(300),
senha VARCHAR(800),
permicoes VARCHAR(800),
foto VARCHAR(800),
email VARCHAR(300),
id_admin INTEGER PRIMARY KEY IDENTITY
);

CREATE TABLE Cargo (
id_cargo INTEGER PRIMARY KEY IDENTITY,
nome VARCHAR(300),
descricao VARCHAR(600),
permicoes VARCHAR(800)
);

CREATE TABLE Funcionario (
id_funcionario INTEGER PRIMARY KEY IDENTITY,
matricula INTEGER,
foto VARCHAR(800),
nascimento DATETIME,
senha VARCHAR(800),
email VARCHAR(300),
genero VARCHAR(1),
nome VARCHAR(300),
cidade VARCHAR(600),
estado VARCHAR(300),
turno VARCHAR(300),
id_cargo INTEGER,
id_loja INTEGER,
FOREIGN KEY(id_loja) REFERENCES Loja (id_loja),
FOREIGN KEY(id_cargo) REFERENCES Cargo (id_cargo)
);

CREATE TABLE Indicador (
id_indicador INTEGER PRIMARY KEY IDENTITY,
nome VARCHAR(300),
indicativa VARCHAR(600)
);

CREATE TABLE Metas (
id_meta INTEGER PRIMARY KEY IDENTITY,
data_fim DATETIME,
descricao VARCHAR(600),
grupo VARCHAR(300),
data_inicio DATETIME,
objet_parcial VARCHAR(300),
objetivo VARCHAR(300),
unidade VARCHAR(300),
objet_parc_dia VARCHAR(300),
referencia VARCHAR(300),
peso INTEGER,
fonte VARCHAR(300),
alter_data NUMERIC(1),
id_cargo INTEGER,
id_indicador INTEGER,
FOREIGN KEY(id_cargo) REFERENCES Cargo (id_cargo),
FOREIGN KEY(id_indicador) REFERENCES Indicador (id_indicador)
);

CREATE TABLE Respota (
data DATETIME,
resultado VARCHAR(300),
id_resposta INTEGER PRIMARY KEY IDENTITY,
autor INTEGER,
justificativa VARCHAR(300),
id_funcionario INTEGER,
id_meta INTEGER,
FOREIGN KEY(id_funcionario) REFERENCES Funcionario (id_funcionario),
FOREIGN KEY(id_meta) REFERENCES Metas (id_meta)
);

CREATE TABLE Ranck (
id_ranck INTEGER PRIMARY KEY IDENTITY,
pontos INTEGER,
mes DATETIME,
posicao INTEGER,
id_funcionario INTEGER,
FOREIGN KEY(id_funcionario) REFERENCES Funcionario (id_funcionario)
);


CREATE TABLE ambito (
id_ambito INTEGER PRIMARY KEY IDENTITY,
id_cargo INTEGER,
id_meta INTEGER,
FOREIGN KEY(id_cargo) REFERENCES Cargo (id_cargo),
FOREIGN KEY(id_meta) REFERENCES Metas (id_meta)
);
