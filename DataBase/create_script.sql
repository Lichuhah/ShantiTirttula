create table if not exists sys_user
(
    id       serial
        constraint sys_user_pk
            primary key,
    login    varchar(255),
    password varchar(255)
);

alter table sys_user
    owner to "Lichuha";

create table if not exists mc_sensor_type
(
    id   serial
        constraint mc_sensor_type_pk
            primary key,
    name varchar(255)
);

alter table mc_sensor_type
    owner to "Lichuha";

create table if not exists mc_device_type
(
    id   serial
        constraint mc_device_type_pk
            primary key,
    name varchar(255)
);

alter table mc_device_type
    owner to "Lichuha";

create table if not exists mc_controller_type
(
    id   serial
        constraint mc_controller_type_pk
            primary key,
    name varchar(255)
);

alter table mc_controller_type
    owner to "Lichuha";

create table if not exists mc_controller
(
    id      serial
        constraint mc_controller_pk
            primary key,
    mac     varchar(12),
    type_id integer
        constraint mc_controller_mc_controller_type_id_fk
            references mc_controller_type
);

alter table mc_controller
    owner to "Lichuha";

create unique index if not exists mc_controller_mac_uindex
    on mc_controller (mac);

create table if not exists mc_controller_auth
(
    id            serial
        constraint mc_controller_auth_pk
            primary key,
    key           varchar(16),
    user_id       integer
        constraint mc_controller_auth_sys_user_id_fk
            references sys_user,
    controller_id integer
        constraint mc_controller_auth_mc_controller_id_fk
            references mc_controller
);

alter table mc_controller_auth
    owner to "Lichuha";

create table if not exists mc_trigger_type
(
    id   serial
        constraint mc_trigger_type_pk
            primary key,
    name varchar(255)
);

alter table mc_trigger_type
    owner to "Lichuha";

create table if not exists mc_sensor
(
    id            serial
        constraint mc_sensor_pk
            primary key,
    controller_id integer
        constraint mc_sensor_mc_controller_id_fk
            references mc_controller,
    type_id       integer
        constraint mc_sensor_mc_sensor_type_id_fk
            references mc_sensor_type,
    number        integer
);

alter table mc_sensor
    owner to "Lichuha";

create table if not exists mc_sensor_data
(
    id        serial
        constraint mc_sensor_data_pk
            primary key,
    auth_id   integer
        constraint mc_sensor_data_mc_controller_auth_id_fk
            references mc_controller_auth,
    sensor_id integer
        constraint mc_sensor_data_mc_sensor_id_fk
            references mc_sensor,
    value     double precision
);

alter table mc_sensor_data
    owner to "Lichuha";

create table if not exists mc_device
(
    id            serial
        constraint mc_device_pk
            primary key,
    controller_id integer
        constraint mc_device_mc_controller_id_fk
            references mc_controller,
    type_id       integer
        constraint mc_device_mc_device_type_id_fk
            references mc_device_type,
    pin           integer,
    analog        boolean
);

alter table mc_device
    owner to "Lichuha";

create table if not exists mc_device_log
(
    id        serial
        constraint mc_device_log_pk
            primary key,
    auth_id   integer
        constraint mc_device_log_mc_controller_auth_id_fk
            references mc_controller_auth,
    device_id integer
        constraint mc_device_log_mc_device_id_fk
            references mc_device,
    value     double precision
);

alter table mc_device_log
    owner to "Lichuha";

create table if not exists mc_trigger
(
    id            serial
        constraint mc_trigger_pk
            primary key,
    type_id       integer
        constraint mc_trigger_mc_trigger_type_id_fk
            references mc_trigger_type,
    sensor_id     integer
        constraint mc_trigger_mc_sensor_id_fk
            references mc_sensor,
    device_id     integer
        constraint mc_trigger_mc_device_id_fk
            references mc_device,
    auth_id       integer
        constraint mc_trigger_mc_controller_auth_id_fk
            references mc_controller_auth,
    trigger_value integer,
    device_value  integer
);

alter table mc_trigger
    owner to "Lichuha";


