CREATE DATABASE itau_invest;
USE itau_invest;

-- Tabela de usuários
CREATE TABLE usuarios (
    id_user INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(50) NOT NULL, 
    email VARCHAR(50) NOT NULL UNIQUE,
    pct_corret DECIMAL(5,4) NOT NULL DEFAULT 0.005
);

-- Tabela de ativos
CREATE TABLE ativos (
    id_ativo INT PRIMARY KEY AUTO_INCREMENT,
    cod VARCHAR(10) NOT NULL, 
    nome VARCHAR(30) NOT NULL
);

-- Tabela de operações
CREATE TABLE operacoes (
    id_op INT PRIMARY KEY AUTO_INCREMENT,
    id_user INT NOT NULL, 
    id_ativo INT NOT NULL,
    qtd INT NOT NULL,
    preco_unit DECIMAL(10,2) NOT NULL,
    tipo_opr ENUM('compra', 'venda') NOT NULL,
    corretagem DECIMAL(10,2) NOT NULL,
    dt_hr DATETIME NOT NULL,
    FOREIGN KEY (id_user) REFERENCES usuarios(id_user),
    FOREIGN KEY (id_ativo) REFERENCES ativos(id_ativo)
);

-- Tabela de cotações
CREATE TABLE cotacoes (
    id_cot INT PRIMARY KEY AUTO_INCREMENT,
    id_ativo INT NOT NULL,
    preco_unit DECIMAL(10,2) NOT NULL,
    dt_hr DATETIME NOT NULL,
    FOREIGN KEY (id_ativo) REFERENCES ativos(id_ativo)
);

-- Tabela de posições
CREATE TABLE posicoes (
    id_pos INT PRIMARY KEY AUTO_INCREMENT,
    id_user INT NOT NULL,
    id_ativo INT NOT NULL,
    qtd INT NOT NULL,
    preco_med DECIMAL(10,2) NOT NULL,
    pl DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (id_user) REFERENCES usuarios(id_user),
    FOREIGN KEY (id_ativo) REFERENCES ativos(id_ativo)
);

-- Criação do Index
CREATE INDEX idx_op_usr_ativo_dt
ON operacoes (id_user, id_ativo, dt_hr);

-- Select otimizado
SELECT * FROM operacoes
WHERE id_usr = ?
AND id_ativo = ?
AND dt_hr >= NOW() - INTERVAL 30 DAY;

-- Trigger de atualização
DELIMITER //

CREATE TRIGGER trg_upd_pos_apos_cot
AFTER INSERT ON cotacoes
FOR EACH ROW
BEGIN
    UPDATE posicoes
    SET pl = (NEW.preco_unit - preco_med) * qtd
    WHERE id_ativo = NEW.id_ativo;
END;
//

DELIMITER ;