DROP TABLE IF EXISTS `character_options`;
CREATE TABLE `character_options` (
  `name` varchar(25) NOT NULL,
  `chat_color_normal` mediumint(8) unsigned NOT NULL DEFAULT '16777215',
  `chat_color_message` mediumint(8) unsigned NOT NULL DEFAULT '16711760',
  `chat_color_system` mediumint(8) unsigned NOT NULL DEFAULT '16739840',
  `chat_use_timestamps` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `key_up_1` int(4) DEFAULT '119',
  `key_up_2` int(4) DEFAULT '273',
  `key_down_1` int(4) DEFAULT '115',
  `key_down_2` int(4) DEFAULT '274',
  `key_left_1` int(4) DEFAULT '97',
  `key_left_2` int(4) DEFAULT '276',
  `key_right_1` int(4) DEFAULT '100',
  `key_right_2` int(4) DEFAULT '275',
  `key_jump_1` int(4) DEFAULT '32',
  `key_jump_2` int(4) DEFAULT '0',
  `key_character_1` int(4) DEFAULT '99',
  `key_character_2` int(4) DEFAULT '0',
  `key_inventory_1` int(4) DEFAULT '105',
  `key_inventory_2` int(4) DEFAULT '0',
  `key_skills_1` int(4) DEFAULT '107',
  `key_skills_2` int(4) DEFAULT '0',
  `key_shortcut_1_1` int(4) DEFAULT '49',
  `key_shortcut_1_2` int(4) DEFAULT '0',
  `key_shortcut_2_1` int(4) DEFAULT '50',
  `key_shortcut_2_2` int(4) DEFAULT '0',
  `key_shortcut_3_1` int(4) DEFAULT '51',
  `key_shortcut_3_2` int(4) DEFAULT '0',
  `key_shortcut_4_1` int(4) DEFAULT '52',
  `key_shortcut_4_2` int(4) DEFAULT '0',
  `key_shortcut_5_1` int(4) DEFAULT '53',
  `key_shortcut_5_2` int(4) DEFAULT '0',
  `key_shortcut_6_1` int(4) DEFAULT '54',
  `key_shortcut_6_2` int(4) DEFAULT '0',
  `key_shortcut_7_1` int(4) DEFAULT '55',
  `key_shortcut_7_2` int(4) DEFAULT '0',
  `key_shortcut_8_1` int(4) DEFAULT '56',
  `key_shortcut_8_2` int(4) DEFAULT '0',
  `key_shortcut_9_1` int(4) DEFAULT '57',
  `key_shortcut_9_2` int(4) DEFAULT '0',
  `key_shortcut_10_1` int(4) DEFAULT '48',
  `key_shortcut_10_2` int(4) DEFAULT '0',
  `key_shortcut_11_1` int(4) DEFAULT '45',
  `key_shortcut_11_2` int(4) DEFAULT '0',
  `key_shortcut_12_1` int(4) DEFAULT '61',
  `key_shortcut_12_2` int(4) DEFAULT '0',
  PRIMARY KEY (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;