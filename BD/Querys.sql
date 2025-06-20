CREATE DATABASE itau_invest;
USE itau_invest;

-- Tabela de usuários
CREATE TABLE usuarios (
    id_usuario INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(50) NOT NULL, 
    email VARCHAR(50) NOT NULL UNIQUE,
    percentual_corretagem DECIMAL(5,4) NOT NULL DEFAULT 0.005
);

-- Tabela de ativos
CREATE TABLE ativos (
    id_ativo INT PRIMARY KEY AUTO_INCREMENT,
    codigo VARCHAR(10) NOT NULL, 
    nome VARCHAR(30) NOT NULL
);

-- Tabela de operações
CREATE TABLE operacoes (
    id_operacao INT PRIMARY KEY AUTO_INCREMENT,
    id_usuario INT NOT NULL, 
    id_ativo INT NOT NULL,
    quantidade INT NOT NULL,
    preco_unitario DECIMAL(10,2) NOT NULL,
    tipo_operacao ENUM('compra', 'venda') NOT NULL,
    corretagem DECIMAL(10,2) NOT NULL,
    data_hora DATETIME NOT NULL,
    FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario),
    FOREIGN KEY (id_ativo) REFERENCES ativos(id_ativo)
);

-- Tabela de cotações
CREATE TABLE cotacoes (
    id_cotacao INT PRIMARY KEY AUTO_INCREMENT,
    id_ativo INT NOT NULL,
    preco_unitario DECIMAL(10,2) NOT NULL,
    data_hora DATETIME NOT NULL,
    FOREIGN KEY (id_ativo) REFERENCES ativos(id_ativo)
);

-- Tabela de posições
CREATE TABLE posicoes (
    id_posicao INT PRIMARY KEY AUTO_INCREMENT,
    id_usuario INT NOT NULL,
    id_ativo INT NOT NULL,
    quantidade INT NOT NULL,
    preco_medio DECIMAL(10,2) NOT NULL,
    p_l DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario),
    FOREIGN KEY (id_ativo) REFERENCES ativos(id_ativo)
);

-- Index cobrindo os campos da consulta principal 
CREATE INDEX idx_operacoes_usuario_ativo_data
ON operacoes (id_usuario, id_ativo, data_hora);


-- Select otimizado
SELECT * FROM operacoes WHERE id_usuario =  
AND id_ativo = 
AND data_hora >= NOW() - INTERVAL 30 DAY;
                        
-- Trigger de Atualização 
DELIMITER //

CREATE TRIGGER atualizar_posicao_apos_cotacao
AFTER INSERT ON cotacoes
FOR EACH ROW
BEGIN
    UPDATE posicoes
    SET p_l = (NEW.preco_unitario - preco_medio) * quantidade
    WHERE id_ativo = NEW.id_ativo;
END;
//

DELIMITER ;