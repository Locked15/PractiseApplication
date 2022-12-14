toc.dat                                                                                             0000600 0004000 0002000 00000050417 14334251632 0014451 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        PGDMP                       
    z            Other_PractiseApplicationData    15.1    15.0 G    N           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false         O           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false         P           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false         Q           1262    16404    Other_PractiseApplicationData    DATABASE     ?   CREATE DATABASE "Other_PractiseApplicationData" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
 /   DROP DATABASE "Other_PractiseApplicationData";
                postgres    false         ?            1259    17039    location    TABLE     ?   CREATE TABLE public.location (
    id integer NOT NULL,
    municipality text NOT NULL,
    floor integer NOT NULL,
    cabinet integer NOT NULL,
    "table" integer
);
    DROP TABLE public.location;
       public         heap    postgres    false         ?            1259    17038    location_id_seq    SEQUENCE     ?   CREATE SEQUENCE public.location_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public.location_id_seq;
       public          postgres    false    223         R           0    0    location_id_seq    SEQUENCE OWNED BY     C   ALTER SEQUENCE public.location_id_seq OWNED BY public.location.id;
          public          postgres    false    222         ?            1259    17050    request    TABLE     y  CREATE TABLE public.request (
    id integer NOT NULL,
    location_id integer,
    request_type_id integer,
    request_status_id integer,
    requester_id integer,
    executioner_id integer,
    title text,
    begin_date timestamp without time zone NOT NULL,
    end_date timestamp without time zone,
    CONSTRAINT not_backtracking_time CHECK ((end_date > begin_date))
);
    DROP TABLE public.request;
       public         heap    postgres    false         ?            1259    17085    request_chat    TABLE     ?   CREATE TABLE public.request_chat (
    id integer NOT NULL,
    request_id integer NOT NULL,
    author_id integer NOT NULL,
    message text,
    sent_date timestamp without time zone NOT NULL
);
     DROP TABLE public.request_chat;
       public         heap    postgres    false         ?            1259    17049    request_id_seq    SEQUENCE     ?   CREATE SEQUENCE public.request_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public.request_id_seq;
       public          postgres    false    225         S           0    0    request_id_seq    SEQUENCE OWNED BY     A   ALTER SEQUENCE public.request_id_seq OWNED BY public.request.id;
          public          postgres    false    224         ?            1259    17084    request_messages_id_seq    SEQUENCE     ?   CREATE SEQUENCE public.request_messages_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public.request_messages_id_seq;
       public          postgres    false    227         T           0    0    request_messages_id_seq    SEQUENCE OWNED BY     O   ALTER SEQUENCE public.request_messages_id_seq OWNED BY public.request_chat.id;
          public          postgres    false    226         ?            1259    17028    request_status    TABLE     Z   CREATE TABLE public.request_status (
    id integer NOT NULL,
    status text NOT NULL
);
 "   DROP TABLE public.request_status;
       public         heap    postgres    false         ?            1259    17027    request_status_id_seq    SEQUENCE     ?   CREATE SEQUENCE public.request_status_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 ,   DROP SEQUENCE public.request_status_id_seq;
       public          postgres    false    221         U           0    0    request_status_id_seq    SEQUENCE OWNED BY     O   ALTER SEQUENCE public.request_status_id_seq OWNED BY public.request_status.id;
          public          postgres    false    220         ?            1259    17019    request_type    TABLE     l   CREATE TABLE public.request_type (
    id integer NOT NULL,
    type text NOT NULL,
    description text
);
     DROP TABLE public.request_type;
       public         heap    postgres    false         ?            1259    17018    request_type_id_seq    SEQUENCE     ?   CREATE SEQUENCE public.request_type_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public.request_type_id_seq;
       public          postgres    false    219         V           0    0    request_type_id_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE public.request_type_id_seq OWNED BY public.request_type.id;
          public          postgres    false    218         ?            1259    16996    role    TABLE     O   CREATE TABLE public.role (
    id integer NOT NULL,
    title text NOT NULL
);
    DROP TABLE public.role;
       public         heap    postgres    false         ?            1259    16995    role_id_seq    SEQUENCE     ?   CREATE SEQUENCE public.role_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 "   DROP SEQUENCE public.role_id_seq;
       public          postgres    false    215         W           0    0    role_id_seq    SEQUENCE OWNED BY     ;   ALTER SEQUENCE public.role_id_seq OWNED BY public.role.id;
          public          postgres    false    214         ?            1259    17005    user    TABLE     ?   CREATE TABLE public."user" (
    id integer NOT NULL,
    role_id integer,
    login text NOT NULL,
    password text NOT NULL,
    first_name text NOT NULL,
    last_name text NOT NULL,
    patronymic text
);
    DROP TABLE public."user";
       public         heap    postgres    false         ?            1259    17004    user_id_seq    SEQUENCE     ?   CREATE SEQUENCE public.user_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 "   DROP SEQUENCE public.user_id_seq;
       public          postgres    false    217         X           0    0    user_id_seq    SEQUENCE OWNED BY     =   ALTER SEQUENCE public.user_id_seq OWNED BY public."user".id;
          public          postgres    false    216         ?            1259    24587    user_review    TABLE     ?   CREATE TABLE public.user_review (
    id integer NOT NULL,
    user_id integer,
    rate numeric(4,2) NOT NULL,
    message text,
    review_time timestamp without time zone NOT NULL
);
    DROP TABLE public.user_review;
       public         heap    postgres    false         ?            1259    24586    user_review_id_seq    SEQUENCE     ?   CREATE SEQUENCE public.user_review_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public.user_review_id_seq;
       public          postgres    false    229         Y           0    0    user_review_id_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public.user_review_id_seq OWNED BY public.user_review.id;
          public          postgres    false    228         ?           2604    17042    location id    DEFAULT     j   ALTER TABLE ONLY public.location ALTER COLUMN id SET DEFAULT nextval('public.location_id_seq'::regclass);
 :   ALTER TABLE public.location ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    222    223    223         ?           2604    17053 
   request id    DEFAULT     h   ALTER TABLE ONLY public.request ALTER COLUMN id SET DEFAULT nextval('public.request_id_seq'::regclass);
 9   ALTER TABLE public.request ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    224    225    225         ?           2604    17088    request_chat id    DEFAULT     v   ALTER TABLE ONLY public.request_chat ALTER COLUMN id SET DEFAULT nextval('public.request_messages_id_seq'::regclass);
 >   ALTER TABLE public.request_chat ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    227    226    227         ?           2604    17031    request_status id    DEFAULT     v   ALTER TABLE ONLY public.request_status ALTER COLUMN id SET DEFAULT nextval('public.request_status_id_seq'::regclass);
 @   ALTER TABLE public.request_status ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    221    220    221         ?           2604    17022    request_type id    DEFAULT     r   ALTER TABLE ONLY public.request_type ALTER COLUMN id SET DEFAULT nextval('public.request_type_id_seq'::regclass);
 >   ALTER TABLE public.request_type ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    219    218    219         ?           2604    16999    role id    DEFAULT     b   ALTER TABLE ONLY public.role ALTER COLUMN id SET DEFAULT nextval('public.role_id_seq'::regclass);
 6   ALTER TABLE public.role ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    214    215    215         ?           2604    17008    user id    DEFAULT     d   ALTER TABLE ONLY public."user" ALTER COLUMN id SET DEFAULT nextval('public.user_id_seq'::regclass);
 8   ALTER TABLE public."user" ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    217    216    217         ?           2604    24590    user_review id    DEFAULT     p   ALTER TABLE ONLY public.user_review ALTER COLUMN id SET DEFAULT nextval('public.user_review_id_seq'::regclass);
 =   ALTER TABLE public.user_review ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    229    228    229         E          0    17039    location 
   TABLE DATA           M   COPY public.location (id, municipality, floor, cabinet, "table") FROM stdin;
    public          postgres    false    223       3397.dat G          0    17050    request 
   TABLE DATA           ?   COPY public.request (id, location_id, request_type_id, request_status_id, requester_id, executioner_id, title, begin_date, end_date) FROM stdin;
    public          postgres    false    225       3399.dat I          0    17085    request_chat 
   TABLE DATA           U   COPY public.request_chat (id, request_id, author_id, message, sent_date) FROM stdin;
    public          postgres    false    227       3401.dat C          0    17028    request_status 
   TABLE DATA           4   COPY public.request_status (id, status) FROM stdin;
    public          postgres    false    221       3395.dat A          0    17019    request_type 
   TABLE DATA           =   COPY public.request_type (id, type, description) FROM stdin;
    public          postgres    false    219       3393.dat =          0    16996    role 
   TABLE DATA           )   COPY public.role (id, title) FROM stdin;
    public          postgres    false    215       3389.dat ?          0    17005    user 
   TABLE DATA           a   COPY public."user" (id, role_id, login, password, first_name, last_name, patronymic) FROM stdin;
    public          postgres    false    217       3391.dat K          0    24587    user_review 
   TABLE DATA           N   COPY public.user_review (id, user_id, rate, message, review_time) FROM stdin;
    public          postgres    false    229       3403.dat Z           0    0    location_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public.location_id_seq', 1, true);
          public          postgres    false    222         [           0    0    request_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.request_id_seq', 3, true);
          public          postgres    false    224         \           0    0    request_messages_id_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public.request_messages_id_seq', 19, true);
          public          postgres    false    226         ]           0    0    request_status_id_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('public.request_status_id_seq', 5, true);
          public          postgres    false    220         ^           0    0    request_type_id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public.request_type_id_seq', 2, true);
          public          postgres    false    218         _           0    0    role_id_seq    SEQUENCE SET     9   SELECT pg_catalog.setval('public.role_id_seq', 2, true);
          public          postgres    false    214         `           0    0    user_id_seq    SEQUENCE SET     9   SELECT pg_catalog.setval('public.user_id_seq', 4, true);
          public          postgres    false    216         a           0    0    user_review_id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public.user_review_id_seq', 1, false);
          public          postgres    false    228         ?           2606    17046    location location_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.location
    ADD CONSTRAINT location_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.location DROP CONSTRAINT location_pkey;
       public            postgres    false    223         ?           2606    17092 "   request_chat request_messages_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY public.request_chat
    ADD CONSTRAINT request_messages_pkey PRIMARY KEY (id);
 L   ALTER TABLE ONLY public.request_chat DROP CONSTRAINT request_messages_pkey;
       public            postgres    false    227         ?           2606    17058    request request_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.request
    ADD CONSTRAINT request_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.request DROP CONSTRAINT request_pkey;
       public            postgres    false    225         ?           2606    17035 "   request_status request_status_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY public.request_status
    ADD CONSTRAINT request_status_pkey PRIMARY KEY (id);
 L   ALTER TABLE ONLY public.request_status DROP CONSTRAINT request_status_pkey;
       public            postgres    false    221         ?           2606    17037 (   request_status request_status_status_key 
   CONSTRAINT     e   ALTER TABLE ONLY public.request_status
    ADD CONSTRAINT request_status_status_key UNIQUE (status);
 R   ALTER TABLE ONLY public.request_status DROP CONSTRAINT request_status_status_key;
       public            postgres    false    221         ?           2606    17026    request_type request_type_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public.request_type
    ADD CONSTRAINT request_type_pkey PRIMARY KEY (id);
 H   ALTER TABLE ONLY public.request_type DROP CONSTRAINT request_type_pkey;
       public            postgres    false    219         ?           2606    17003    role role_pkey 
   CONSTRAINT     L   ALTER TABLE ONLY public.role
    ADD CONSTRAINT role_pkey PRIMARY KEY (id);
 8   ALTER TABLE ONLY public.role DROP CONSTRAINT role_pkey;
       public            postgres    false    215         ?           2606    17048    location unique_location 
   CONSTRAINT     t   ALTER TABLE ONLY public.location
    ADD CONSTRAINT unique_location UNIQUE (municipality, floor, cabinet, "table");
 B   ALTER TABLE ONLY public.location DROP CONSTRAINT unique_location;
       public            postgres    false    223    223    223    223         ?           2606    17012    user user_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_pkey PRIMARY KEY (id);
 :   ALTER TABLE ONLY public."user" DROP CONSTRAINT user_pkey;
       public            postgres    false    217         ?           2606    24594    user_review user_review_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public.user_review
    ADD CONSTRAINT user_review_pkey PRIMARY KEY (id);
 F   ALTER TABLE ONLY public.user_review DROP CONSTRAINT user_review_pkey;
       public            postgres    false    229         ?           2606    17079 #   request request_executioner_id_fkey    FK CONSTRAINT     ?   ALTER TABLE ONLY public.request
    ADD CONSTRAINT request_executioner_id_fkey FOREIGN KEY (executioner_id) REFERENCES public."user"(id);
 M   ALTER TABLE ONLY public.request DROP CONSTRAINT request_executioner_id_fkey;
       public          postgres    false    3220    225    217         ?           2606    17059     request request_location_id_fkey    FK CONSTRAINT     ?   ALTER TABLE ONLY public.request
    ADD CONSTRAINT request_location_id_fkey FOREIGN KEY (location_id) REFERENCES public.location(id);
 J   ALTER TABLE ONLY public.request DROP CONSTRAINT request_location_id_fkey;
       public          postgres    false    225    223    3228         ?           2606    17098 ,   request_chat request_messages_author_id_fkey    FK CONSTRAINT     ?   ALTER TABLE ONLY public.request_chat
    ADD CONSTRAINT request_messages_author_id_fkey FOREIGN KEY (author_id) REFERENCES public."user"(id);
 V   ALTER TABLE ONLY public.request_chat DROP CONSTRAINT request_messages_author_id_fkey;
       public          postgres    false    3220    227    217         ?           2606    17093 -   request_chat request_messages_request_id_fkey    FK CONSTRAINT     ?   ALTER TABLE ONLY public.request_chat
    ADD CONSTRAINT request_messages_request_id_fkey FOREIGN KEY (request_id) REFERENCES public.request(id);
 W   ALTER TABLE ONLY public.request_chat DROP CONSTRAINT request_messages_request_id_fkey;
       public          postgres    false    225    3232    227         ?           2606    17069 &   request request_request_status_id_fkey    FK CONSTRAINT     ?   ALTER TABLE ONLY public.request
    ADD CONSTRAINT request_request_status_id_fkey FOREIGN KEY (request_status_id) REFERENCES public.request_status(id);
 P   ALTER TABLE ONLY public.request DROP CONSTRAINT request_request_status_id_fkey;
       public          postgres    false    221    3224    225         ?           2606    17064 $   request request_request_type_id_fkey    FK CONSTRAINT     ?   ALTER TABLE ONLY public.request
    ADD CONSTRAINT request_request_type_id_fkey FOREIGN KEY (request_type_id) REFERENCES public.request_type(id);
 N   ALTER TABLE ONLY public.request DROP CONSTRAINT request_request_type_id_fkey;
       public          postgres    false    3222    219    225         ?           2606    17074 !   request request_requester_id_fkey    FK CONSTRAINT     ?   ALTER TABLE ONLY public.request
    ADD CONSTRAINT request_requester_id_fkey FOREIGN KEY (requester_id) REFERENCES public."user"(id);
 K   ALTER TABLE ONLY public.request DROP CONSTRAINT request_requester_id_fkey;
       public          postgres    false    225    217    3220         ?           2606    24595 $   user_review user_review_user_id_fkey    FK CONSTRAINT     ?   ALTER TABLE ONLY public.user_review
    ADD CONSTRAINT user_review_user_id_fkey FOREIGN KEY (user_id) REFERENCES public."user"(id);
 N   ALTER TABLE ONLY public.user_review DROP CONSTRAINT user_review_user_id_fkey;
       public          postgres    false    217    3220    229         ?           2606    17013    user user_role_id_fkey    FK CONSTRAINT     v   ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_role_id_fkey FOREIGN KEY (role_id) REFERENCES public.role(id);
 B   ALTER TABLE ONLY public."user" DROP CONSTRAINT user_role_id_fkey;
       public          postgres    false    3218    217    215                                                                                                                                                                                                                                                         3397.dat                                                                                            0000600 0004000 0002000 00000000612 14334251632 0014261 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	МЗИО	1	1	\N
2	МЗИО	1	2	\N
3	Казначейство	1	3	\N
4	Казначейство	1	4	\N
5	Казначейство	1	5	\N
6	Казначейство	1	6	\N
7	МЗИО	1	101	\N
8	МЗИО	1	102	\N
9	Казначейство	3	327	2
10	Казначейство	3	327	6
11	Казначейство	4	407	3
12	IT	4	413	1
13	IT	4	413	2
14	IT	4	413	3
15	IT	4	413	4
16	IT	4	413	5
\.


                                                                                                                      3399.dat                                                                                            0000600 0004000 0002000 00000000442 14334251632 0014264 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	8	1	5	4	3	Сломался Принтер!	2022-11-13 11:52:48.396455	2022-11-14 00:30:05.690444
3	2	1	5	4	4	Help Wanted	2022-11-13 20:22:33.344551	2022-11-14 00:32:09.221812
2	14	2	5	4	3	Требуется Разработчик	2022-11-13 20:19:40.368496	2022-11-14 00:52:52.03163
\.


                                                                                                                                                                                                                              3401.dat                                                                                            0000600 0004000 0002000 00000004420 14334251632 0014244 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	1	4	Что случилось, и вот теперь он не печатает.	2022-11-13 11:53:43.127892
2	2	4	Возникла необходимость срочно разработать необходимое ПО для сдачи в срок. Требуется ПОМОЩЬ!	2022-11-13 20:20:16.42618
3	3	4	Принтер сломался. Картридж меняли.	2022-11-13 20:22:55.085936
4	1	4	А вы не пробовали его... ну, подключить к питанию?	2022-11-13 23:51:58.110818
5	1	4	Пробовали, конечно.	2022-11-13 23:53:10.588865
6	1	4	И как?	2022-11-13 23:53:18.704684
7	1	4	А НИЧЕГО!	2022-11-13 23:53:23.833182
8	1	3	Ну, честно говоря, я не знаю...	2022-11-14 00:23:04.796803
9	1	4	А что думать? Нужно картридж менять. Пора сделать ЭТО!	2022-11-14 00:26:30.060455
10	1	3	Перебрал картридж. (Ну и грязно было). Теперь все должно работать правильно.	2022-11-14 00:28:24.873167
11	1	3	Поступило сообщение, что он опять не работает. Открываю заявку заново.	2022-11-14 00:29:29.936319
12	1	3	Ладно, отбой. Я просто сменил драм-барабан. Протестил, теперь оно работает.	2022-11-14 00:30:05.668526
13	3	4	Я разберусь с этим.	2022-11-14 00:31:22.531294
14	3	4	Да это важный принтер. Меняю приоритет...	2022-11-14 00:31:54.42462
15	3	4	Вроде работает. Ну, проверим.	2022-11-14 00:32:09.215801
16	2	4	Это не так важно. Можно отложить. Да и перекинуть на кого-нибудь...	2022-11-14 00:33:38.122946
17	2	4	Так, нужно разбираться с этим.\nГалиуллин Алмаз изменил статус:\nОтложенный -> Важный.	2022-11-14 00:41:34.493436
18	2	4	Галиуллин Алмаз изменил статус:\nCastle.Proxies.RequestStatusProxy -> Критический.	2022-11-14 00:51:56.592215
19	2	4	Галиуллин Алмаз изменил статус:\nКритический -> Решенный.	2022-11-14 00:52:52.014321
\.


                                                                                                                                                                                                                                                3395.dat                                                                                            0000600 0004000 0002000 00000000144 14334251632 0014257 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	Новый
2	Важный
3	Критический
4	Отложенный
5	Решенный
\.


                                                                                                                                                                                                                                                                                                                                                                                                                            3393.dat                                                                                            0000600 0004000 0002000 00000000432 14334251632 0014255 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	Аппаратная Проблема	Проблема с оборудованием (например, не работает принтер).
2	Проблема с ПО	Проблема с используемым ПО (например, не запускается Excel).
\.


                                                                                                                                                                                                                                      3389.dat                                                                                            0000600 0004000 0002000 00000000114 14334251632 0014257 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	Пользователь
2	Администратор
3	Мастер
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                    3391.dat                                                                                            0000600 0004000 0002000 00000000440 14334251632 0014252 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	1	abdrag13	AbdRAG_13	Абдрахман	Эникеевич	\N
2	1	calcMD	calcATcalc@10	Ксения	Габдуллина	Арефьева
3	2	dev\\NULL	toNULL_\\all-1	Эрик	Епифанцев	\N
4	3	Locked15	ToTest_AndBeyond	Алмаз	Галиуллин	Рамазанович
\.


                                                                                                                                                                                                                                3403.dat                                                                                            0000600 0004000 0002000 00000000005 14334251632 0014241 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           restore.sql                                                                                         0000600 0004000 0002000 00000037637 14334251632 0015407 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        --
-- NOTE:
--
-- File paths need to be edited. Search for $$PATH$$ and
-- replace it with the path to the directory containing
-- the extracted data files.
--
--
-- PostgreSQL database dump
--

-- Dumped from database version 15.1
-- Dumped by pg_dump version 15.0

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE "Other_PractiseApplicationData";
--
-- Name: Other_PractiseApplicationData; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "Other_PractiseApplicationData" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';


ALTER DATABASE "Other_PractiseApplicationData" OWNER TO postgres;

\connect "Other_PractiseApplicationData"

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: location; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.location (
    id integer NOT NULL,
    municipality text NOT NULL,
    floor integer NOT NULL,
    cabinet integer NOT NULL,
    "table" integer
);


ALTER TABLE public.location OWNER TO postgres;

--
-- Name: location_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.location_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.location_id_seq OWNER TO postgres;

--
-- Name: location_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.location_id_seq OWNED BY public.location.id;


--
-- Name: request; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.request (
    id integer NOT NULL,
    location_id integer,
    request_type_id integer,
    request_status_id integer,
    requester_id integer,
    executioner_id integer,
    title text,
    begin_date timestamp without time zone NOT NULL,
    end_date timestamp without time zone,
    CONSTRAINT not_backtracking_time CHECK ((end_date > begin_date))
);


ALTER TABLE public.request OWNER TO postgres;

--
-- Name: request_chat; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.request_chat (
    id integer NOT NULL,
    request_id integer NOT NULL,
    author_id integer NOT NULL,
    message text,
    sent_date timestamp without time zone NOT NULL
);


ALTER TABLE public.request_chat OWNER TO postgres;

--
-- Name: request_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.request_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.request_id_seq OWNER TO postgres;

--
-- Name: request_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.request_id_seq OWNED BY public.request.id;


--
-- Name: request_messages_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.request_messages_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.request_messages_id_seq OWNER TO postgres;

--
-- Name: request_messages_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.request_messages_id_seq OWNED BY public.request_chat.id;


--
-- Name: request_status; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.request_status (
    id integer NOT NULL,
    status text NOT NULL
);


ALTER TABLE public.request_status OWNER TO postgres;

--
-- Name: request_status_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.request_status_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.request_status_id_seq OWNER TO postgres;

--
-- Name: request_status_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.request_status_id_seq OWNED BY public.request_status.id;


--
-- Name: request_type; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.request_type (
    id integer NOT NULL,
    type text NOT NULL,
    description text
);


ALTER TABLE public.request_type OWNER TO postgres;

--
-- Name: request_type_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.request_type_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.request_type_id_seq OWNER TO postgres;

--
-- Name: request_type_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.request_type_id_seq OWNED BY public.request_type.id;


--
-- Name: role; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.role (
    id integer NOT NULL,
    title text NOT NULL
);


ALTER TABLE public.role OWNER TO postgres;

--
-- Name: role_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.role_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.role_id_seq OWNER TO postgres;

--
-- Name: role_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.role_id_seq OWNED BY public.role.id;


--
-- Name: user; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."user" (
    id integer NOT NULL,
    role_id integer,
    login text NOT NULL,
    password text NOT NULL,
    first_name text NOT NULL,
    last_name text NOT NULL,
    patronymic text
);


ALTER TABLE public."user" OWNER TO postgres;

--
-- Name: user_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.user_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.user_id_seq OWNER TO postgres;

--
-- Name: user_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.user_id_seq OWNED BY public."user".id;


--
-- Name: user_review; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.user_review (
    id integer NOT NULL,
    user_id integer,
    rate numeric(4,2) NOT NULL,
    message text,
    review_time timestamp without time zone NOT NULL
);


ALTER TABLE public.user_review OWNER TO postgres;

--
-- Name: user_review_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.user_review_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.user_review_id_seq OWNER TO postgres;

--
-- Name: user_review_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.user_review_id_seq OWNED BY public.user_review.id;


--
-- Name: location id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.location ALTER COLUMN id SET DEFAULT nextval('public.location_id_seq'::regclass);


--
-- Name: request id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.request ALTER COLUMN id SET DEFAULT nextval('public.request_id_seq'::regclass);


--
-- Name: request_chat id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.request_chat ALTER COLUMN id SET DEFAULT nextval('public.request_messages_id_seq'::regclass);


--
-- Name: request_status id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.request_status ALTER COLUMN id SET DEFAULT nextval('public.request_status_id_seq'::regclass);


--
-- Name: request_type id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.request_type ALTER COLUMN id SET DEFAULT nextval('public.request_type_id_seq'::regclass);


--
-- Name: role id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.role ALTER COLUMN id SET DEFAULT nextval('public.role_id_seq'::regclass);


--
-- Name: user id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."user" ALTER COLUMN id SET DEFAULT nextval('public.user_id_seq'::regclass);


--
-- Name: user_review id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.user_review ALTER COLUMN id SET DEFAULT nextval('public.user_review_id_seq'::regclass);


--
-- Data for Name: location; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.location (id, municipality, floor, cabinet, "table") FROM stdin;
\.
COPY public.location (id, municipality, floor, cabinet, "table") FROM '$$PATH$$/3397.dat';

--
-- Data for Name: request; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.request (id, location_id, request_type_id, request_status_id, requester_id, executioner_id, title, begin_date, end_date) FROM stdin;
\.
COPY public.request (id, location_id, request_type_id, request_status_id, requester_id, executioner_id, title, begin_date, end_date) FROM '$$PATH$$/3399.dat';

--
-- Data for Name: request_chat; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.request_chat (id, request_id, author_id, message, sent_date) FROM stdin;
\.
COPY public.request_chat (id, request_id, author_id, message, sent_date) FROM '$$PATH$$/3401.dat';

--
-- Data for Name: request_status; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.request_status (id, status) FROM stdin;
\.
COPY public.request_status (id, status) FROM '$$PATH$$/3395.dat';

--
-- Data for Name: request_type; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.request_type (id, type, description) FROM stdin;
\.
COPY public.request_type (id, type, description) FROM '$$PATH$$/3393.dat';

--
-- Data for Name: role; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.role (id, title) FROM stdin;
\.
COPY public.role (id, title) FROM '$$PATH$$/3389.dat';

--
-- Data for Name: user; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."user" (id, role_id, login, password, first_name, last_name, patronymic) FROM stdin;
\.
COPY public."user" (id, role_id, login, password, first_name, last_name, patronymic) FROM '$$PATH$$/3391.dat';

--
-- Data for Name: user_review; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.user_review (id, user_id, rate, message, review_time) FROM stdin;
\.
COPY public.user_review (id, user_id, rate, message, review_time) FROM '$$PATH$$/3403.dat';

--
-- Name: location_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.location_id_seq', 1, true);


--
-- Name: request_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.request_id_seq', 3, true);


--
-- Name: request_messages_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.request_messages_id_seq', 19, true);


--
-- Name: request_status_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.request_status_id_seq', 5, true);


--
-- Name: request_type_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.request_type_id_seq', 2, true);


--
-- Name: role_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.role_id_seq', 2, true);


--
-- Name: user_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.user_id_seq', 4, true);


--
-- Name: user_review_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.user_review_id_seq', 1, false);


--
-- Name: location location_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.location
    ADD CONSTRAINT location_pkey PRIMARY KEY (id);


--
-- Name: request_chat request_messages_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.request_chat
    ADD CONSTRAINT request_messages_pkey PRIMARY KEY (id);


--
-- Name: request request_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.request
    ADD CONSTRAINT request_pkey PRIMARY KEY (id);


--
-- Name: request_status request_status_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.request_status
    ADD CONSTRAINT request_status_pkey PRIMARY KEY (id);


--
-- Name: request_status request_status_status_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.request_status
    ADD CONSTRAINT request_status_status_key UNIQUE (status);


--
-- Name: request_type request_type_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.request_type
    ADD CONSTRAINT request_type_pkey PRIMARY KEY (id);


--
-- Name: role role_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.role
    ADD CONSTRAINT role_pkey PRIMARY KEY (id);


--
-- Name: location unique_location; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.location
    ADD CONSTRAINT unique_location UNIQUE (municipality, floor, cabinet, "table");


--
-- Name: user user_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_pkey PRIMARY KEY (id);


--
-- Name: user_review user_review_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.user_review
    ADD CONSTRAINT user_review_pkey PRIMARY KEY (id);


--
-- Name: request request_executioner_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.request
    ADD CONSTRAINT request_executioner_id_fkey FOREIGN KEY (executioner_id) REFERENCES public."user"(id);


--
-- Name: request request_location_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.request
    ADD CONSTRAINT request_location_id_fkey FOREIGN KEY (location_id) REFERENCES public.location(id);


--
-- Name: request_chat request_messages_author_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.request_chat
    ADD CONSTRAINT request_messages_author_id_fkey FOREIGN KEY (author_id) REFERENCES public."user"(id);


--
-- Name: request_chat request_messages_request_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.request_chat
    ADD CONSTRAINT request_messages_request_id_fkey FOREIGN KEY (request_id) REFERENCES public.request(id);


--
-- Name: request request_request_status_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.request
    ADD CONSTRAINT request_request_status_id_fkey FOREIGN KEY (request_status_id) REFERENCES public.request_status(id);


--
-- Name: request request_request_type_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.request
    ADD CONSTRAINT request_request_type_id_fkey FOREIGN KEY (request_type_id) REFERENCES public.request_type(id);


--
-- Name: request request_requester_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.request
    ADD CONSTRAINT request_requester_id_fkey FOREIGN KEY (requester_id) REFERENCES public."user"(id);


--
-- Name: user_review user_review_user_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.user_review
    ADD CONSTRAINT user_review_user_id_fkey FOREIGN KEY (user_id) REFERENCES public."user"(id);


--
-- Name: user user_role_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_role_id_fkey FOREIGN KEY (role_id) REFERENCES public.role(id);


--
-- PostgreSQL database dump complete
--

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 