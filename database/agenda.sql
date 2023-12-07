create database agenda;
use agenda;

create table tbcontato(
	codcontato int primary key not null auto_increment,
    nome varchar(100),
    telefone char(14),
    celular char(15),
    email varchar(100)
);

insert into tbcontato(nome, telefone, celular, email) values ('João Botão', '(11) 4002-8922', '(11) 98492-9475', 'botaojoao@gmail.com');