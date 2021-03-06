﻿using System;
using AutoMapper;
using ShopAssist2.Business.Interfaces;
using ShopAssist2.Common.DataTransferObjects;
using ShopAssist2.Common.Entities;
using ShopAssist2.Common.Persistence;

namespace ShopAssist2.Business.Services {
    public class UserService : IUserService {
        private readonly ShopAssist2Context _ctx;
        private readonly IMapper _mapper;
        public UserService(ShopAssist2Context shopAssist2Context, IMapper mapper) {
            _ctx = shopAssist2Context;
            _mapper = mapper;
        }

        //public IEnumerable<UserDto> GetAll() {

        //}

        public UserDto GetByUserId(int userId) {
            var user = _ctx.Users.Find(userId);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        public void AddUser(UserDto userDto) {
            if(userDto == null)
                throw new ArgumentNullException(nameof(userDto));

            var user = _mapper.Map<User>(userDto);
            _ctx.Users.Add(user);
            _ctx.SaveChanges();

        }

        public void UpdateUser(UserDto user) {
            _ctx.Users.Find(user.UserId);
            _ctx.Entry(_mapper.Map<User>(user)).State = System.Data.Entity.EntityState.Modified;
            _ctx.SaveChanges();
        }
    }
}