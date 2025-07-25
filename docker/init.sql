
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET search_path = public;

CREATE SCHEMA IF NOT EXISTS public;

CREATE TABLE IF NOT EXISTS public."Tarefas" (
    "Id" uuid NOT NULL PRIMARY KEY,
    "Titulo" text NOT NULL,
    "Descricao" text NOT NULL,
    "Status" integer NOT NULL,
    "DataCriacao" timestamp with time zone NOT NULL,
    "DataConclusao" timestamp with time zone,
    "DataAtualizacao" timestamp with time zone
);

CREATE TABLE IF NOT EXISTS public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL PRIMARY KEY,
    "ProductVersion" character varying(32) NOT NULL
);

INSERT INTO public."Tarefas" ("Id", "Titulo", "Descricao", "Status", "DataCriacao", "DataConclusao", "DataAtualizacao")
VALUES
('3463e947-a795-4ed9-a940-c7fbcddee012', 'Criar uma API .NET', 'Versão 9 .NET Core', 0, '2025-07-22 14:28:16-03', NULL, '2025-07-24 18:40:26-03'),
('a8aed6a3-39f1-42f1-82f1-42a3adcc23f4', 'Estudar', 'PostgreSQL', 2, '2025-07-24 18:28:45-03', '2025-07-24 19:03:04-03', '2025-07-24 19:03:04-03'),
('7841d736-cf50-4c4e-b5aa-ca04a1139f55', 'Projeto', 'Criar um gerenciador de tarefas', 1, '2025-07-24 18:32:40-03', NULL, '2025-07-24 18:54:23-03')
ON CONFLICT ("Id") DO NOTHING;

INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES
('20250722172433_InitialCreate', '8.0.18'),
('20250723171152_DataAtualizacao', '8.0.18')
ON CONFLICT ("MigrationId") DO NOTHING;
