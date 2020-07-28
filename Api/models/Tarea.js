'use strict';

const { Sequelize, DataTypes, Model } = require('sequelize');
const sequelize = new Sequelize({
    dialect: 'sqlite',
    storage: './storage/database.sqllite'
});

const Tarea = sequelize.define('Tarea', {
    id: {
        primaryKey: true,
        type: Sequelize.BIGINT,
        autoIncrement: true,
    },
    titulo: {
        type: Sequelize.STRING,
    },
    detalle: {
        type: Sequelize.STRING,
    },
    lugar: {
        type: Sequelize.STRING,
    },
    fecha: {
        type: Sequelize.STRING,
    },
});

Tarea.sync();

module.exports = Tarea;