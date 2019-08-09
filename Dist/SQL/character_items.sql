CREATE TABLE IF NOT EXISTS `character_items` (
  `owner` varchar(25) DEFAULT NULL,
  `slot_id` int(4) DEFAULT '0',
  `item_id` int(4) DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
