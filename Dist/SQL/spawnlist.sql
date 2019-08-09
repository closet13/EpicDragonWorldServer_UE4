CREATE TABLE IF NOT EXISTS `spawnlist` (
  `npc_id` int(4) DEFAULT '0',
  `x` float DEFAULT '0',
  `y` float DEFAULT '0',
  `z` float DEFAULT '0',
  `heading` int(4) DEFAULT '0',
  `respawn_time` int(4) DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;