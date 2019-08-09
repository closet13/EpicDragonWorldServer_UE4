CREATE TABLE IF NOT EXISTS `items` (
  `item_id` int(4) DEFAULT '0',
  `slot` enum('NONE','HEAD','CHEST','LEGS','HANDS','FEET','LEFT_HAND','RIGHT_HAND') DEFAULT 'NONE' NOT NULL,
  `type` enum('JUNK','EQUIP','CONSUME') DEFAULT 'JUNK' NOT NULL,
  `stackable` tinyint(1) UNSIGNED NOT NULL DEFAULT '0',
  `tradable` tinyint(1) UNSIGNED NOT NULL DEFAULT '0',
  `stamina` int(4) DEFAULT '0',
  `strength` int(4) DEFAULT '0',
  `dexterity` int(4) DEFAULT '0',
  `intelect` int(4) DEFAULT '0',
  `skill_id` int(4) DEFAULT '0',
  `skill_level` int(4) DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO `items` VALUES ('1', 'CHEST', 'EQUIP', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `items` VALUES ('2', 'LEGS', 'EQUIP', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `items` VALUES ('3', 'FEET', 'EQUIP', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `items` VALUES ('4', 'RIGHT_HAND', 'EQUIP', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `items` VALUES ('5', 'LEFT_HAND', 'EQUIP', '0', '0', '0', '0', '0', '0', '0', '0');