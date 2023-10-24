

CREATE TABLE IF NOT EXISTS public."Passager"
(
    id bigint generated always as identity NOT NULL,
    service text NOT NULL,
    created_at timestamp with time zone NOT NULL,
    updated_at timestamp with time zone NOT NULL,
    is_male boolean NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS public."Machine"
(
    id bigint generated always as identity NOT NULL,
    driver_id bigint references "Driver"(id) NOT NULL,
    car_id bigint references "Car"(id) NOT NULL,
    created_at timestamp with time zone NOT NULL,
    updated_at timestamp with time zone,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS public."Car"
(
    id bigint generated always as identity  NOT NULL,
    car_name character varying(50),
    "number" text NOT NULL,
    color text,
    start_date timestamp with time zone NOT NULL,
    status text,
    description text,
    created_at timestamp with time zone NOT NULL,
    updated_at timestamp with time zone,
    image_path text NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS public.location
(
    id bigint NOT NULL,
    city character varying(20) NOT NULL,
    street character varying(20) NOT NULL,
    house bigint,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS public.booking
(
    id bigint generated always as identity NOT NULL,
    "startPosition" bigint references "location"(id)  NOT NULL,
    "endPosition" bigint references "location"(id) NOT NULL,
    passenger_id bigint references "Passager"(id) NOT NULL,
    driver_id bigint references "Driver"(id) NOT NULL,
    price real NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS public."Driver"
(
    id bigint generated always as identity  NOT NULL,
    user_id bigint references "User"(id) NOT NULL,
    password text NOT NULL,
    rating text NOT NULL,
    image_path text NOT NULL,
    prava_seria text NOT NULL,
    working date NOT NULL,
    created_at timestamp with time zone NOT NULL,
    updated_at timestamp with time zone,
    PRIMARY KEY (id)
);

