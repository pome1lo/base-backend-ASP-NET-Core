﻿using AutoMapper;
using BusinessLogic.Exceptions;
using BusinessLogicLayer.Services.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccess.Data.Interfaces;
using DataAccess.Models;
using FluentValidation;

namespace BusinessLogicLayer.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<ProfileDto> _profileValidator;
        private readonly IValidator<UpdateProfileDto> _updateProfileValidator;

        public ProfileService(
            IRepository<User> userRepository,
            IMapper mapper,
            IValidator<ProfileDto> profileValidator,
            IValidator<UpdateProfileDto> updateProfileValidator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _profileValidator = profileValidator;
            _updateProfileValidator = updateProfileValidator;
        }

        public async Task<ProfileDto> GetProfileByIdAsync(int profileId, CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.GetItemAsync(profileId, cancellationToken);

            if (user is null)
            {
                throw new NotFoundException($"Profile with ID {profileId} not found.");
            }

            return _mapper.Map<ProfileDto>(user);
        }

        public async Task<IEnumerable<ProfileDto>> GetAllProfilesAsync(CancellationToken cancellationToken = default)
        {
            var users = await _userRepository.GetElementsAsync(cancellationToken);
            return _mapper.Map<IEnumerable<ProfileDto>>(users);
        }
          
        public async Task UpdateProfileAsync(int profileId, UpdateProfileDto updateProfileDto, CancellationToken cancellationToken = default)
        {
            var validationResult = await _updateProfileValidator.ValidateAsync(updateProfileDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var existingUser = await _userRepository.GetItemAsync(profileId, cancellationToken);
            if (existingUser is null)
            {
                throw new NotFoundException($"Profile with ID {profileId} not found.");
            }

            var user = _mapper.Map(updateProfileDto, existingUser);
            await _userRepository.UpdateAsync(profileId, user, cancellationToken);
        }

        public async Task DeleteProfileAsync(int profileId, CancellationToken cancellationToken = default)
        {
            var existingUser = await _userRepository.GetItemAsync(profileId, cancellationToken);
            if (existingUser is null)
            {
                throw new NotFoundException($"Profile with ID {profileId} not found.");
            }

            await _userRepository.DeleteAsync(profileId, cancellationToken);
        }
    }
}
